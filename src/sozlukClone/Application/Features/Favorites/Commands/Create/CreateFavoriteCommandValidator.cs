using FluentValidation;

namespace Application.Features.Favorites.Commands.Create;

public class CreateFavoriteCommandValidator : AbstractValidator<CreateFavoriteCommand>
{
    public CreateFavoriteCommandValidator()
    {
        RuleFor(c => c.EntryId).NotEmpty();
        RuleFor(c => c.AuthorId).NotEmpty();
    }
}