using FluentValidation;

namespace Application.Features.TitleBlockings.Commands.Update;

public class UpdateTitleBlockingCommandValidator : AbstractValidator<UpdateTitleBlockingCommand>
{
    public UpdateTitleBlockingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}