using System;
using System.Collections.Generic;

namespace LearningDiary.WebUI.ViewModels
{
    public record SavePointVM
    {
        public Guid Id { get; init; }
        public DateTime CreatedDate { get; init; }
        public string Title { get; init; }
        public string Type { get; init; }
        public string Status { get; init; }
        public IList<string> Tags { get; init; }
    }
}
