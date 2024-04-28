using FluentValidation;

namespace Application.Features.PenaltyTypes.Commands.Create;

public class CreatePenaltyTypeCommandValidator : AbstractValidator<CreatePenaltyTypeCommand>
{
    public CreatePenaltyTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}