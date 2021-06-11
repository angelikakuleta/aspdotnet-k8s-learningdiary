using LearningDiary.Domain.Entities;
using LearningDiary.Domain.ValueObjects;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace LearningDiary.Infrastructure.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        public MongoDbContext(IOptions<MongoDbSettings> options)
        {
            var settings = options.Value;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.Database);

            SavePoints = database.GetCollection<SavePoint>(typeof(SavePoint).Name.ToLower());
            MongoDbContextSeeder.SeedData(this);
            ClassMapping();
        }

        public IMongoCollection<SavePoint> SavePoints { get; }

        private static void ClassMapping()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(SavePoint)))
            {
                BsonClassMap.RegisterClassMap<SavePoint>(cm =>
                {
                    cm.AutoMap();
                    cm.GetMemberMap(x => x.Status).SetSerializer(new EnumSerializer<SavePointStatus>(BsonType.String));
                    cm.GetMemberMap(x => x.Type).SetSerializer(new EnumSerializer<SavePointType>(BsonType.String));
                    cm.GetMemberMap(x => x.Link).SetIgnoreIfNull(true);
                    cm.SetIdMember(cm.GetMemberMap(x => x.Id));
                });
            }
        }
    }
}
