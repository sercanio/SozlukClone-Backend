using FluentValidation;

namespace Application.Features.Dislikes.Commands.Create;

public class CreateDislikeCommandValidator : AbstractValidator<CreateDislikeCommand>
{
    public CreateDislikeCommandValidator()
    {
        RuleFor(c => c.EntryId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}