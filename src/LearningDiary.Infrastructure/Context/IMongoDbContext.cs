using LearningDiary.Domain.Entities;
using MongoDB.Driver;

namespace LearningDiary.Infrastructure.Context
{
    public interface IMongoDbContext
    {
        IMongoCollection<SavePoint> SavePoints { get; }
    }
}