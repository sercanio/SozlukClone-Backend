using FluentValidation;

namespace Application.Features.AuthorGroups.Commands.Create;

public class CreateAuthorGroupCommandValidator : AbstractValidator<CreateAuthorGroupCommand>
{
    public CreateAuthorGroupCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Color).NotEmpty();
    }
}