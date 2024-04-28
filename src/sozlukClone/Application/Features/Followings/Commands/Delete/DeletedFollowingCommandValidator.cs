using FluentValidation;

namespace Application.Features.Followings.Commands.Delete;

public class DeleteFollowingCommandValidator : AbstractValidator<DeleteFollowingCommand>
{
    public DeleteFollowingCommandValidator()
    {
        RuleFor(c => c.FollowerId).NotEmpty();
        RuleFor(c => c.FollowedId).NotEmpty();
    }
}