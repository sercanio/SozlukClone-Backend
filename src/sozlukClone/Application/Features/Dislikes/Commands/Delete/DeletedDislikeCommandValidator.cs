using FluentValidation;

namespace Application.Features.Dislikes.Commands.Delete;

public class DeleteDislikeCommandValidator : AbstractValidator<DeleteDislikeCommand>
{
    public DeleteDislikeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}