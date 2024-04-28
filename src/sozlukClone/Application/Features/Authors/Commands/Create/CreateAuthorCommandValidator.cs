using FluentValidation;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(c => c.UserName).NotEmpty();
        RuleFor(c => c.Biography).NotEmpty();
        RuleFor(c => c.ProfilePictureUrl).NotEmpty();
        RuleFor(c => c.CoverPictureUrl).NotEmpty();
        RuleFor(c => c.AuthorGroupId).NotEmpty();
        RuleFor(c => c.ActiveBadgeId).NotEmpty();
    }
}