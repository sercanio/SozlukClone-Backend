using FluentValidation;

namespace Application.Features.TitleBlockings.Commands.Delete;

public class DeleteTitleBlockingCommandValidator : AbstractValidator<DeleteTitleBlockingCommand>
{
    public DeleteTitleBlockingCommandValidator()
    {
        RuleFor(c => c.TitleId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}