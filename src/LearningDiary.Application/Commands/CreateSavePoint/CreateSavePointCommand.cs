using LearningDiary.Application.Responses;
using LearningDiary.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;

namespace LearningDiary.Application.Commands.CreateSavePoint
{
    public class CreateSavePointCommand : IRequest<BaseResponse<Guid>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Nickname { get; set; }
        public SavePointType Type { get; set; }
        public Uri Link { get; set; }
        public SavePointStatus Status { get; set; }
        public ISet<string> Tags { get; set; }
    }
}
