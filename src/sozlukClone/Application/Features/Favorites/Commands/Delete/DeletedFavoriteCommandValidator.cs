using FluentValidation;

namespace Application.Features.Favorites.Commands.Delete;

public class DeleteFavoriteCommandValidator : AbstractValidator<DeleteFavoriteCommand>
{
    public DeleteFavoriteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}