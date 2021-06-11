using LearningDiary.Domain.Entities;
using LearningDiary.Domain.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace LearningDiary.Infrastructure.Context
{
    internal static class MongoDbContextSeeder
    {
        internal static void SeedData(MongoDbContext context)
        {
            bool existsSavePoints = context.SavePoints.Find(x => true).Any();
            if (!existsSavePoints)
            {
                context.SavePoints.InsertMany(GetPreconfigSavePoints());
            }
        }

        private static IEnumerable<SavePoint> GetPreconfigSavePoints()
        {
            var appUser = new AppUser("nerd20");

            return new List<SavePoint>()
            {
                new SavePoint()
                {
                    Id = Guid.Parse("2de9e338-2525-4f6a-b456-8093021fe798"),
                    CreatedDate = DateTime.Now.AddMinutes(-66),
                    Title = "Deploying a Docker based web application to Azure App Service",
                    Link = new Uri("https://docs.microsoft.com"),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "azure" },
                    Type = SavePointType.Tutorial,
                    Status = SavePointStatus.ReadyToStart,
                    AppUser = appUser
                },
                new SavePoint()
                {
                    Id = Guid.Parse("c8beff61-cf4b-4e8f-be43-78df15e84314"),
                    CreatedDate = DateTime.Now.AddMinutes(-166),
                    Title = "Create a web API with ASP.NET Core and MongoDB",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "dotnet", "mongodb" },
                    Type = SavePointType.Article,
                    Status = SavePointStatus.Finished,
                    AppUser = appUser
                },
                new SavePoint()
                {
                    Id = Guid.Parse("507470ac-aac9-4f0f-977a-84b47bb6735b"),
                    CreatedDate = DateTime.Now.AddMinutes(-234),
                    Title = "How to Add MongoDb to a Kubernetes",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "kubernetes", "mongodb" },
                    Type = SavePointType.Article,
                    Status = SavePointStatus.Finished,
                    AppUser = appUser
                },
                new SavePoint()
                {
                    Id = Guid.Parse("82894652-101b-40d9-9df6-e0500d592fd4"),
                    CreatedDate = DateTime.Now.AddMinutes(-365),
                    Title = "A brief Intro to clean Architecture, DDD and CQRS",
                    Link = new Uri("https://docs.microsoft.com"),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "ddd", "cqrs" },
                    Type = SavePointType.Video,
                    Status = SavePointStatus.Finished,
                    AppUser = appUser
                },
                new SavePoint()
                {
                    Id = Guid.Parse("f0cce026-6c26-4873-b9aa-ebcd46ae099d"),
                    CreatedDate = DateTime.Now.AddMinutes(-881),
                    Title = "CQRS with MediatR Pattern in Asp.net Core Web Api",
                    Link = new Uri("https://docs.microsoft.com"),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "cqrs", "mediatr", "dotnet" },
                    Type = SavePointType.AcademicJournal,
                    Status = SavePointStatus.InProgress,
                    AppUser = appUser
                },
                new SavePoint()
                {
                    Id = Guid.Parse("53ed28fc-54e8-41c7-b390-b892b3bfc9f7"),
                    CreatedDate = DateTime.Now.AddMinutes(-1500),
                    Title = "MediatR Validation Behaviour",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "mediatr" },
                    Type = SavePointType.Tutorial,
                    Status = SavePointStatus.InProgress,
                    AppUser = appUser
                },
                new SavePoint()
                {
                    Id = Guid.Parse("fb28451a-1119-449e-9889-c539306c639c"),
                    CreatedDate = DateTime.Now.AddMinutes(-1862),
                    Title = "Kubernete Networking Guide",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "kubernetes" },
                    Type = SavePointType.Article,
                    Status = SavePointStatus.Finished,
                    AppUser = appUser
                },
                new SavePoint()
                {
                    Id = Guid.Parse("9dbb2b4d-f645-45cf-a0a6-5aa4b654a89b"),
                    CreatedDate = DateTime.Now.AddMinutes(-3412),
                    Title = "Set up Ingress on Minikube with NGINX Ingress Controller",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    Tags = new HashSet<string>() { "kubernetes", "nginx" },
                    Type = SavePointType.Video,
                    Status = SavePointStatus.Finished,
                    AppUser = appUser
                },
            };
        }
    }
}