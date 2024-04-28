using FluentValidation;

namespace Application.Features.Badges.Commands.Update;

public class UpdateBadgeCommandValidator : AbstractValidator<UpdateBadgeCommand>
{
    public UpdateBadgeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.IconUrl).NotEmpty();
    }
}