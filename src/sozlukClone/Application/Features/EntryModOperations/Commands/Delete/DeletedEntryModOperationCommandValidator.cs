using FluentValidation;

namespace Application.Features.EntryModOperations.Commands.Delete;

public class DeleteEntryModOperationCommandValidator : AbstractValidator<DeleteEntryModOperationCommand>
{
    public DeleteEntryModOperationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}