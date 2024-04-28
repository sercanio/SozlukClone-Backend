using FluentValidation;

namespace Application.Features.Badges.Commands.Create;

public class CreateBadgeCommandValidator : AbstractValidator<CreateBadgeCommand>
{
    public CreateBadgeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.IconUrl).NotEmpty();
    }
}