using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LearningDiary.WebUI.Clients;
using Microsoft.AspNetCore.Authorization;
using LearningDiary.WebUI.ViewModels;

namespace LearningDiary.WebUI.Pages
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ISavePointClient _client;

        public DeleteModel(ISavePointClient client)
        {
            _client = client;
        }

        [BindProperty]
        public SavePointDetailsVM SavePointDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SavePointDetails = await _client.Get((Guid)id);

            if (SavePointDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _client.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
