using Application.Features.Dislikes.Queries.GetList;
using Application.Features.Favorites.Queries.GetList;
using Application.Features.Likes.Queries.GetList;
using Application.Features.Titles.Queries.GetList;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Entries.Queries.GetList;

public class GetListEntryListItemProfilePageDto : IDto
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

    //public GetListAuthorListItemDto Author { get; set; }
    public GetListTitleListItemDto Title { get; set; }
}