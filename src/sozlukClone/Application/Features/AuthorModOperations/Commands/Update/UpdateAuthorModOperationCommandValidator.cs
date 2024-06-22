using FluentValidation;

namespace Application.Features.AuthorModOperations.Commands.Update;

public class UpdateAuthorModOperationCommandValidator : AbstractValidator<UpdateAuthorModOperationCommand>
{
    public UpdateAuthorModOperationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.ModOperationId).NotEmpty();
    }
}