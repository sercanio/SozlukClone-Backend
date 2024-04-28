using FluentValidation;

namespace Application.Features.PenaltyTypes.Commands.Update;

public class UpdatePenaltyTypeCommandValidator : AbstractValidator<UpdatePenaltyTypeCommand>
{
    public UpdatePenaltyTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}