using FluentValidation;

namespace Application.Features.EntryModOperations.Commands.Update;

public class UpdateEntryModOperationCommandValidator : AbstractValidator<UpdateEntryModOperationCommand>
{
    public UpdateEntryModOperationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EntryId).NotEmpty();
        RuleFor(c => c.ModOperationId).NotEmpty();
    }
}