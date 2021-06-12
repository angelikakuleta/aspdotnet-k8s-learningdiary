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
    public class DetailsModel : PageModel
    {
        private readonly ISavePointClient _client;

        public DetailsModel(ISavePointClient client)
        {
            _client = client;
        }

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
    }
}
