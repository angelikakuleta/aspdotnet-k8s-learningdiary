using LearningDiary.Domain.Contracts;
using LearningDiary.Infrastructure.Context;
using LearningDiary.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace LearningDiary.Infrastructure
{
    public static partial class LearningDiaryRegistration
    {
        public static IServiceCollection AddInfrastructureWithMongoDbServices(
            this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<MongoDbSettings>(options => configuration.GetSection(nameof(MongoDbSettings)).Bind(options));
            services.AddSingleton<MongoDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddScoped<ISavePointRepository, SavePointRepository>();

            return services;
        }
    }
}
