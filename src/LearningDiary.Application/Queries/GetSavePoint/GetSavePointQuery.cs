using LearningDiary.Application.Responses;
using MediatR;
using System;

namespace LearningDiary.Application.Queries.GetSavePoint
{
    public class GetSavePointQuery : IRequest<BaseResponse<SavePointDetailsVM>>
    {
        public Guid Id { get; set; }
    }
}
