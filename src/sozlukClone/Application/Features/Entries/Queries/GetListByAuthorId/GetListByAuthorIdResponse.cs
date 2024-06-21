using Application.Features.Authors.Queries.GetList;
using Application.Features.Dislikes.Queries.GetList;
using Application.Features.Favorites.Queries.GetList;
using Application.Features.Likes.Queries.GetList;
using Application.Features.Titles.Queries.GetList;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Queries.GetListByAuthorId;

public class GetListByAuthorIdResponse : IResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
    public int FavoriteCount { get; set; }

    public GetListAuthorListItemDto Author { get; set; }
    public GetListTitleListItemInHomePageDto Title { get; set; }

    public ICollection<GetListLikeListItemInEntryDto> Likes { get; set; }
    public ICollection<GetListDislikeListItemInEntryDto> Dislikes { get; set; }
    public ICollection<GetListFavoriteListItemInEntryDto> Favorites { get; set; }
}
