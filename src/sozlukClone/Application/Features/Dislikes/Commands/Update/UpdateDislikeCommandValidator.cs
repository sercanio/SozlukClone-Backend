using FluentValidation;

namespace Application.Features.Dislikes.Commands.Update;

public class UpdateDislikeCommandValidator : AbstractValidator<UpdateDislikeCommand>
{
    public UpdateDislikeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EntryId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}