using FluentValidation;

namespace Application.Features.AuthorFollowings.Commands.Update;

public class UpdateAuthorFollowingCommandValidator : AbstractValidator<UpdateAuthorFollowingCommand>
{
    public UpdateAuthorFollowingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FollowerId).NotEmpty();
        RuleFor(c => c.FollowingId).NotEmpty();
    }
}