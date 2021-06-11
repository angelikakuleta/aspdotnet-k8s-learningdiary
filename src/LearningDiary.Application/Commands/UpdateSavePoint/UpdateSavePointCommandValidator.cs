using FluentValidation;

namespace LearningDiary.Application.Commands.UpdateSavePoint
{
    class UpdateSavePointCommandValidator : AbstractValidator<UpdateSavePointCommand>
    {
        public UpdateSavePointCommandValidator()
        {
            RuleFor(x => x.Title)
                .MinimumLength(2).MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.Type)
                .IsInEnum();
        }
    }
}
