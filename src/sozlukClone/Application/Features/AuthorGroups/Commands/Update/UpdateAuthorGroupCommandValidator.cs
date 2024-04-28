using FluentValidation;

namespace Application.Features.AuthorGroups.Commands.Update;

public class UpdateAuthorGroupCommandValidator : AbstractValidator<UpdateAuthorGroupCommand>
{
    public UpdateAuthorGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}