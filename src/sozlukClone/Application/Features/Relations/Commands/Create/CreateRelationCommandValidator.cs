using FluentValidation;

namespace Application.Features.Relations.Commands.Create;

public class CreateRelationCommandValidator : AbstractValidator<CreateRelationCommand>
{
    public CreateRelationCommandValidator()
    {
        RuleFor(c => c.FollowerId).NotEmpty();
        RuleFor(c => c.FollowingId).NotEmpty();
    }
}