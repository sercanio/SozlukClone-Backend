using FluentValidation;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommandValidator : AbstractValidator<CreatePenaltyCommand>
{
    public CreatePenaltyCommandValidator()
    {
        RuleFor(c => c.Reason).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.PenaltyTypeId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.IssuerId).NotEmpty();
    }
}