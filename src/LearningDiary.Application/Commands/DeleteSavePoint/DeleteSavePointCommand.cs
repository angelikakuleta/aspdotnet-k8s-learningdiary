using LearningDiary.Application.Responses;
using MediatR;
using System;

namespace LearningDiary.Application.Commands.DeleteSavePoint
{
    public class DeleteSavePointCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
    }
}
