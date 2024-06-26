using Application.Features.Users.Queries.GetById;
using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Queries.GetByUserName;

public class GetByUserNameResponse : IResponse
{
    // core information
    public int Id { get; set; }
    public string UserName { get; set; }
    public string? Biography { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? CoverPictureUrl { get; set; }
    public int? Age { get; set; }
    public GenderEnum? Gender { get; set; }
    public int AuthorGroupId { get; set; }
    public int ActiveBadgeId { get; set; }

    // statistics
    public int EntryCount { get; set; }
    public int TitleCount { get; set; }
    public int FollowingCount { get; set; }
    public int FollowerCount { get; set; }
    public int BlockingsCount { get; set; }
    public int BlockersCount { get; set; }
    public int GivenLikesCount { get; set; }
    public int GivenDislikesCount { get; set; }
    public int GivenFavoritesCount { get; set; }
    public int ReceivedLikesCount { get; set; }
    public int ReceivedDislikesCount { get; set; }
    public int ReceivedFavoritesCount { get; set; }
    public int FollowedTitlesMultiplier { get; set; }
    public int BlockedTitlesCount { get; set; }
    public int ComplaintCount { get; set; }
    public int ComplaintPendingCount { get; set; }
    public int ComplaintApprovedCount { get; set; }
    public int ComplaintRejectedCount { get; set; }
    public int ComplaintedEntriesCount { get; set; }
    public int ComplaintedTitlesCount { get; set; }
    public int Karma { get; set; }

    public GetByIdUserInAuthorResponse User { get; set; }
}
