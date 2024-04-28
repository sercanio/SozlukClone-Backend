using FluentValidation;

namespace Application.Features.AuthorGroups.Commands.Delete;

public class DeleteAuthorGroupCommandValidator : AbstractValidator<DeleteAuthorGroupCommand>
{
    public DeleteAuthorGroupCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}