using FluentValidation;

namespace Application.Features.AuthorFollowings.Commands.Delete;

public class DeleteAuthorFollowingCommandValidator : AbstractValidator<DeleteAuthorFollowingCommand>
{
    public DeleteAuthorFollowingCommandValidator()
    {
        RuleFor(c => c.FollowingId).NotEmpty();
        RuleFor(c => c.FollowerId).NotEmpty();
    }
}