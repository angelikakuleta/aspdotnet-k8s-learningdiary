using LearningDiary.Domain.Common;
using LearningDiary.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace LearningDiary.Domain.Entities
{
    public class SavePoint : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public AppUser AppUser { get; set; }
        public SavePointType Type { get; set; }
        public Uri? Link { get; set; }
        public SavePointStatus Status { get; set; }
        public ISet<string> Tags { get; set; }

        public bool IsFinished => Status == SavePointStatus.Finished;
    }
}
