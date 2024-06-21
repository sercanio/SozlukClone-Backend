using NArchitecture.Core.Application.Responses;

namespace Application.Features.Favorites.Commands.Update;

public class UpdatedFavoriteResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}