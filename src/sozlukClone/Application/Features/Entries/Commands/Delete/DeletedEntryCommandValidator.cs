using FluentValidation;

namespace Application.Features.Entries.Commands.Delete;

public class DeleteEntryCommandValidator : AbstractValidator<DeleteEntryCommand>
{
    public DeleteEntryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}