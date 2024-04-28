using FluentValidation;

namespace Application.Features.Followings.Commands.Update;

public class UpdateFollowingCommandValidator : AbstractValidator<UpdateFollowingCommand>
{
    public UpdateFollowingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FollowerId).NotEmpty();
        RuleFor(c => c.FollowedId).NotEmpty();
    }
}