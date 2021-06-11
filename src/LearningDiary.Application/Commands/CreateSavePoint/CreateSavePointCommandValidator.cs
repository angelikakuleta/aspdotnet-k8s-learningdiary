using FluentValidation;

namespace LearningDiary.Application.Commands.CreateSavePoint
{
    class CreateSavePointCommandValidator : AbstractValidator<CreateSavePointCommand>
    {
        public CreateSavePointCommandValidator()
        {
            RuleFor(x => x.Nickname)
                .NotEmpty();

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
