using AutoMapper;
using LearningDiary.Application.Commands.CreateSavePoint;
using LearningDiary.Application.Commands.UpdateSavePoint;
using LearningDiary.Application.Queries.GetSavePoint;
using LearningDiary.Application.Queries.GetSavePointsByAppUser;
using LearningDiary.Domain.Entities;
using LearningDiary.Domain.ValueObjects;

namespace LearningDiary.Application.Profiles
{
    public class SavePointProfile : Profile
    {
        public SavePointProfile()
        {
            CreateMap<string, AppUser>().ConstructUsing(c => new AppUser(c));
            CreateMap<SavePoint, SavePointVM>();
            CreateMap<SavePoint, SavePointDetailsVM>();
            CreateMap<CreateSavePointCommand, SavePoint>()
                .ForMember(d => d.AppUser, o => o.MapFrom(x => new AppUser(x.Nickname)));
            CreateMap<UpdateSavePointCommand, SavePoint>();
        }
    }
}
