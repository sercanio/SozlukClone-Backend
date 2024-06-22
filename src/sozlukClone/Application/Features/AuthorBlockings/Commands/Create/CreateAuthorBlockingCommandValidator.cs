using FluentValidation;

namespace Application.Features.AuthorBlockings.Commands.Create;

public class CreateAuthorBlockingCommandValidator : AbstractValidator<CreateAuthorBlockingCommand>
{
    public CreateAuthorBlockingCommandValidator()
    {
        RuleFor(c => c.BlockerId).NotEmpty();
        RuleFor(c => c.BlockingId).NotEmpty();
    }
}