using NArchitecture.Core.Application.Responses;

namespace Application.Features.Favorites.Queries.GetById;

public class GetByIdFavoriteResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}