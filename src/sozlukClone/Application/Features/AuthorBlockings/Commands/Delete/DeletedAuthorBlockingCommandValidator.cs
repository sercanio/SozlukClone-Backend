using FluentValidation;

namespace Application.Features.AuthorBlockings.Commands.Delete;

public class DeleteAuthorBlockingCommandValidator : AbstractValidator<DeleteAuthorBlockingCommand>
{
    public DeleteAuthorBlockingCommandValidator()
    {
        RuleFor(c => c.BlockingId).NotEmpty();
        RuleFor(c => c.BlockerId).NotEmpty();
    }
}