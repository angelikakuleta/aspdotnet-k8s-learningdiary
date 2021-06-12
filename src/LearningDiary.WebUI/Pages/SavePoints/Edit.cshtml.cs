using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LearningDiary.WebUI.ViewModels;
using LearningDiary.WebUI.Clients;

namespace LearningDiary.WebUI.Pages.SavePoints
{
    public class EditModel : PageModel
    {
        private readonly ISavePointClient _client;

        public EditModel(ISavePointClient client)
        {
            _client = client;
        }

        [BindProperty]
        public UpdateSavePointVM UpdateSavePointVM { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savePoint = await _client.Get((Guid)id);

            if (savePoint == null)
            {
                return NotFound();
            }

            UpdateSavePointVM = new UpdateSavePointVM
            {
                Id = savePoint.Id,
                Description = savePoint.Description,
                Link = savePoint.Link,       
                Title = savePoint.Title
            };

            Tags = string.Join(' ', savePoint.Tags);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UpdateSavePointVM.Tags = Tags.Split(' ', StringSplitOptions.RemoveEmptyEntries).Distinct();
            await _client.Update(UpdateSavePointVM);

            return RedirectToPage("./Index");
        }
    }
}