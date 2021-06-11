using LearningDiary.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LearningDiary.Application.Queries.GetSavePointsByAppUser
{
    public class GetSavePointsByAppUserQuery : IRequest<BaseResponse<List<SavePointVM>>>
    {
        public string Nickname { get; set; }
    }
}
