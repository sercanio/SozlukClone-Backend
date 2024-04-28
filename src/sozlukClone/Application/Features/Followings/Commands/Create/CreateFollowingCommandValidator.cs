using FluentValidation;

namespace Application.Features.Followings.Commands.Create;

public class CreateFollowingCommandValidator : AbstractValidator<CreateFollowingCommand>
{
    public CreateFollowingCommandValidator()
    {
        RuleFor(c => c.FollowerId).NotEmpty();
        RuleFor(c => c.FollowedId).NotEmpty();
    }
}