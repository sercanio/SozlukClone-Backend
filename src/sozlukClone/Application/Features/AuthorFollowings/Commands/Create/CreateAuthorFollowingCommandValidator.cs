using FluentValidation;

namespace Application.Features.AuthorFollowings.Commands.Create;

public class CreateAuthorFollowingCommandValidator : AbstractValidator<CreateAuthorFollowingCommand>
{
    public CreateAuthorFollowingCommandValidator()
    {
        RuleFor(c => c.FollowerId).NotEmpty();
        RuleFor(c => c.FollowingId).NotEmpty();
    }
}