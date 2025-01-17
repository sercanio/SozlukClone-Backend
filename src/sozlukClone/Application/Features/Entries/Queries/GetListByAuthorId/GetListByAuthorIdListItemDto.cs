using Application.Features.Authors.Queries.GetById;
using Application.Features.Titles.Queries.GetById;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Queries.GetListByAuthorId;

public class GetListByAuthorIdListItemDto : IResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int LikesCount { get; set; }
    public int DislikesCount { get; set; }
    public int FavoritesCount { get; set; }
    public bool AuthorLike { get; set; }
    public bool AuthorDislike { get; set; }
    public bool AuthorFavorite { get; set; }
    public Guid LikeId { get; set; }
    public Guid DislikeId { get; set; }
    public Guid FavoriteId { get; set; }
    public GetByIdTitleForEntryResponse Title { get; set; }
    public GetByIdAuthorForEntryResponse Author { get; set; }
}
