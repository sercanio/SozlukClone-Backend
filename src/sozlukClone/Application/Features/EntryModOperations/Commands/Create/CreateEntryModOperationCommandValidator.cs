using FluentValidation;

namespace Application.Features.EntryModOperations.Commands.Create;

public class CreateEntryModOperationCommandValidator : AbstractValidator<CreateEntryModOperationCommand>
{
    public CreateEntryModOperationCommandValidator()
    {
        RuleFor(c => c.EntryId).NotEmpty();
        RuleFor(c => c.ModOperationId).NotEmpty();
    }
}