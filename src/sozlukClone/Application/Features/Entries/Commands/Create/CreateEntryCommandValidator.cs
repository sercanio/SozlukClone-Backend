using FluentValidation;

namespace Application.Features.Entries.Commands.Create;

public class CreateEntryCommandValidator : AbstractValidator<CreateEntryCommand>
{
    public CreateEntryCommandValidator()
    {
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
    }
}