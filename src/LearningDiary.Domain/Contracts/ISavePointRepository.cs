using LearningDiary.Domain.Entities;
using LearningDiary.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDiary.Domain.Contracts
{
    public interface ISavePointRepository
    {
        Task<SavePoint> AddAsync(SavePoint savePoint);
        Task<SavePoint> UpdateAsync(SavePoint savePoint);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<SavePoint>> GetAllByAppUserAsync(AppUser appUser);
        Task<SavePoint> FindByIdAsync(Guid id);
    }
}
