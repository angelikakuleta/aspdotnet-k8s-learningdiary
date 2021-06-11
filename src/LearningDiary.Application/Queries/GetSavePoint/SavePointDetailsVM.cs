using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningDiary.Application.Queries.GetSavePoint
{
    public record SavePointDetailsVM
    {
        public Guid Id { get; init; }
        public DateTime CreatedDate { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string Type { get; init; }
        public Uri? Link { get; init; }
        public string Status { get; init; }
        public IList<string> Tags { get; init; }
    }
}
