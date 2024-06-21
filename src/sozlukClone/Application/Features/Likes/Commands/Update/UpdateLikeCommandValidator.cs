using FluentValidation;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommandValidator : AbstractValidator<UpdateLikeCommand>
{
    public UpdateLikeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.EntryId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}