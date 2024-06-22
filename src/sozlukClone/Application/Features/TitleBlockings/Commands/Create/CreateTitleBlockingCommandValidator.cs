using FluentValidation;

namespace Application.Features.TitleBlockings.Commands.Create;

public class CreateTitleBlockingCommandValidator : AbstractValidator<CreateTitleBlockingCommand>
{
    public CreateTitleBlockingCommandValidator()
    {
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}