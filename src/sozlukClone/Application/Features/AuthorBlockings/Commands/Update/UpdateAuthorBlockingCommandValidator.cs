using FluentValidation;

namespace Application.Features.AuthorBlockings.Commands.Update;

public class UpdateAuthorBlockingCommandValidator : AbstractValidator<UpdateAuthorBlockingCommand>
{
    public UpdateAuthorBlockingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BlockerId).NotEmpty();
        RuleFor(c => c.BlockingId).NotEmpty();
    }
}