using System.ComponentModel.DataAnnotations;

namespace LearningDiary.WebUI.ViewModels
{
    public enum SavePointStatus
    {
        [Display(Name = "Ready to Start")]
        ReadyToStart = 0,
        [Display(Name = "In progress")]
        InProgress,
        Finished
    }
}