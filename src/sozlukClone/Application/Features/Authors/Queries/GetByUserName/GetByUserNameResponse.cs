using Application.Features.Users.Queries.GetById;
using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Queries.GetByUserName;

public class GetByUserNameResponse : IResponse
{
    public uint Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string? Biography { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? CoverPictureUrl { get; set; }
    public byte? Age { get; set; }
    public GenderEnum? Gender { get; set; }
    public uint AuthorGroupId { get; set; }
    public uint ActiveBadgeId { get; set; }
    public int TitleCount { get; set; }
    public int EntryCount { get; set; }
    public GetByIdUserInAuthorResponse User { get; set; }
    //public virtual ICollection<GetListRelationListItemDto> Followers { get; set; }
    //public virtual ICollection<GetListRelationListItemDto> Followings { get; set; }

    //public ICollection<GetListLikeListItemInEntryDto> Likes { get; set; }
    //public ICollection<GetListDislikeListItemInEntryDto> Dislikes { get; set; }
    //public ICollection<GetListFavoriteListItemInEntryDto> Favorites { get; set; }

}
