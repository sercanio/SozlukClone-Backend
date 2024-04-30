using FluentValidation;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Delete;

public class DeleteAuthorGroupUserOperationClaimCommandValidator : AbstractValidator<DeleteAuthorGroupUserOperationClaimCommand>
{
    public DeleteAuthorGroupUserOperationClaimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}