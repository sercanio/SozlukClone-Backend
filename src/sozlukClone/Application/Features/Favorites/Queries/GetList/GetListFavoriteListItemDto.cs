using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Favorites.Queries.GetList;

public class GetListFavoriteListItemDto : IDto
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}