using Application.Features.Authors.Queries.GetById;
using Application.Features.Dislikes.Queries.GetList;
using Application.Features.Favorites.Queries.GetList;
using Application.Features.Likes.Queries.GetList;
using Application.Features.Titles.Queries.GetById;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Queries.GetById;

public class GetByIdEntryResponse : IResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public ICollection<GetListLikeListItemInEntryDto> Likes { get; set; }
    public ICollection<GetListDislikeListItemInEntryDto> Dislikes { get; set; }
    public ICollection<GetListFavoriteListItemInEntryDto> Favorites { get; set; }

    public GetByIdTitleForEntryResponse Title { get; set; }
    public GetByIdAuthorForEntryResponse Author { get; set; }
}