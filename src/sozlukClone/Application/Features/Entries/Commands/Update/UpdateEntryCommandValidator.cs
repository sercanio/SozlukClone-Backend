using FluentValidation;

namespace Application.Features.Entries.Commands.Update;

public class UpdateEntryCommandValidator : AbstractValidator<UpdateEntryCommand>
{
    public UpdateEntryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.TitleId).NotEmpty();
    }
}