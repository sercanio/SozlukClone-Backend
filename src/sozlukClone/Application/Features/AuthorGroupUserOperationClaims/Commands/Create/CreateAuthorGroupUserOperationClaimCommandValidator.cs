using FluentValidation;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Create;

public class CreateAuthorGroupUserOperationClaimCommandValidator : AbstractValidator<CreateAuthorGroupUserOperationClaimCommand>
{
    public CreateAuthorGroupUserOperationClaimCommandValidator()
    {
        RuleFor(c => c.OperationClaimId).NotEmpty();
        RuleFor(c => c.AuthorGroupId).NotEmpty();
    }
}