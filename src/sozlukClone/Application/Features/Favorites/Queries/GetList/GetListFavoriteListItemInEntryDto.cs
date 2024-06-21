using Application.Features.Authors.Queries.GetById;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Favorites.Queries.GetList;

public class GetListFavoriteListItemInEntryDto : IDto
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }

    public GetByIdAuthorForEntryResponse Author { get; set; }
}