using LearningDiary.Domain.Contracts;
using LearningDiary.Domain.Entities;
using LearningDiary.Domain.ValueObjects;
using LearningDiary.Infrastructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDiary.Infrastructure.Repositories
{
    public class SavePointRepository : ISavePointRepository
    {
        private readonly IMongoCollection<SavePoint> _collection;

        public SavePointRepository(IMongoDbContext context)
        {
            _collection = context.SavePoints;
        }

        public async Task<SavePoint> AddAsync(SavePoint savePoint)
        {
            savePoint.CreatedDate = DateTime.Now;

            await _collection.InsertOneAsync(savePoint);
            return savePoint;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var deleteResult = await _collection.DeleteOneAsync(x => x.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<SavePoint> FindByIdAsync(Guid id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SavePoint>> GetAllByAppUserAsync(AppUser appUser)
        {
            return await _collection
                .Find(x => x.AppUser == appUser)
                .ToListAsync();
        }

        public async Task<SavePoint> UpdateAsync(SavePoint savePoint)
        {
            savePoint.LastModifiedDate = DateTime.Now;

            return await _collection.FindOneAndReplaceAsync(x => x.Id == savePoint.Id, savePoint);
        }
    }
}
