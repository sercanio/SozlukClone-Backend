using FluentValidation;

namespace Application.Features.AuthorModOperations.Commands.Delete;

public class DeleteAuthorModOperationCommandValidator : AbstractValidator<DeleteAuthorModOperationCommand>
{
    public DeleteAuthorModOperationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}