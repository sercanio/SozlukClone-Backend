using FluentValidation;

namespace Application.Features.Badges.Commands.Delete;

public class DeleteBadgeCommandValidator : AbstractValidator<DeleteBadgeCommand>
{
    public DeleteBadgeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}