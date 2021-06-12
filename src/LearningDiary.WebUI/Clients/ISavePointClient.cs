using LearningDiary.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDiary.WebUI.Clients
{
    public interface ISavePointClient
    {
        Task Add(CreateSavePointVM model);
        Task Update(UpdateSavePointVM model);
        Task<SavePointDetailsVM> Get(Guid id);
        Task<IList<SavePointVM>> GetAll(string nickname);
        Task Delete(Guid? id);
    }
}