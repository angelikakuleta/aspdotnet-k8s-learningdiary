using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningDiary.WebUI.ViewModels
{
    public class CreateSavePointVM
    {
        [Required]
        [MinLength(3), MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public SavePointType Type { get; set; }

        public Uri Link { get; set; }

        [Required]
        public SavePointStatus Status { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}
