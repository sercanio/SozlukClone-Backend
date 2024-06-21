using NArchitecture.Core.Application.Responses;

namespace Application.Features.Favorites.Commands.Delete;

public class DeletedFavoriteResponse : IResponse
{
    public Guid Id { get; set; }
}