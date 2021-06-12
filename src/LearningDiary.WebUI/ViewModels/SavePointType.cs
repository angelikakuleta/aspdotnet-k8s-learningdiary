using System.ComponentModel.DataAnnotations;

namespace LearningDiary.WebUI.ViewModels
{
    public enum SavePointType
    {
        Article = 0,
        Tutorial,
        Video,
        Podcast,
        [Display(Name = "Academic Journal")]
        AcademicJournal
    }
}
