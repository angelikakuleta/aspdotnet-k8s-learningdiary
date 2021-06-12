using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LearningDiary.WebUI.Clients;
using Microsoft.AspNetCore.Authorization;
using LearningDiary.WebUI.ViewModels;
using System.Linq;

namespace LearningDiary.WebUI.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ISavePointClient _client;

        public CreateModel(ISavePointClient client)
        {
            _client = client;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateSavePointVM SavePointDetailsVM { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SavePointDetailsVM.Tags = Tags.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Distinct();
            await _client.Add(SavePointDetailsVM);

            return RedirectToPage("./Index");
        }
    }
}
