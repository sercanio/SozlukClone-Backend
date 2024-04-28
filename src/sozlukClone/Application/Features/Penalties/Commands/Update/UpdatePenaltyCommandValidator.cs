using FluentValidation;

namespace Application.Features.Penalties.Commands.Update;

public class UpdatePenaltyCommandValidator : AbstractValidator<UpdatePenaltyCommand>
{
    public UpdatePenaltyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Reason).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.PenaltyTypeId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.IssuerId).NotEmpty();
    }
}