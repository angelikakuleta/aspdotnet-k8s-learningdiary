using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LearningDiary.WebUI.Clients;
using Microsoft.AspNetCore.Authorization;
using LearningDiary.WebUI.ViewModels;

namespace LearningDiary.WebUI.Pages.SavePoints
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ISavePointClient _client;

        public IndexModel(ISavePointClient client)
        {
            _client = client;
        }

        public IList<SavePointVM> SavePointList { get;set; }

        public async Task OnGetAsync()
        {
            var nickname = User.Identity.Name;
            SavePointList = await _client.GetAll(nickname);
        }
    }
}
