using FluentValidation;

namespace Application.Features.AuthorModOperations.Commands.Create;

public class CreateAuthorModOperationCommandValidator : AbstractValidator<CreateAuthorModOperationCommand>
{
    public CreateAuthorModOperationCommandValidator()
    {
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.ModOperationId).NotEmpty();
    }
}