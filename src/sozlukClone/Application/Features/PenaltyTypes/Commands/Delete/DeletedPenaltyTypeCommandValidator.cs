using FluentValidation;

namespace Application.Features.PenaltyTypes.Commands.Delete;

public class DeletePenaltyTypeCommandValidator : AbstractValidator<DeletePenaltyTypeCommand>
{
    public DeletePenaltyTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}