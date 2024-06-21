using FluentValidation;

namespace Application.Features.Relations.Commands.Update;

public class UpdateRelationCommandValidator : AbstractValidator<UpdateRelationCommand>
{
    public UpdateRelationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FollowerId).NotEmpty();
        RuleFor(c => c.FollowingId).NotEmpty();
    }
}