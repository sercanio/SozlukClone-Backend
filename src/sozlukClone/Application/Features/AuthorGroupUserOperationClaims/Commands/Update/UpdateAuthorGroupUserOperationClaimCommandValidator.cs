using FluentValidation;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Update;

public class UpdateAuthorGroupUserOperationClaimCommandValidator : AbstractValidator<UpdateAuthorGroupUserOperationClaimCommand>
{
    public UpdateAuthorGroupUserOperationClaimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OperationClaimId).NotEmpty();
        RuleFor(c => c.AuthorGroupId).NotEmpty();
    }
}