using FluentValidation;

namespace Application.Features.Authors.Commands.Update;

public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
{
    public UpdateAuthorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.UserName).NotEmpty();
        RuleFor(c => c.AuthorGroupId).NotEmpty();
        RuleFor(c => c.ActiveBadgeId).NotEmpty();
    }
}