using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Followings.Queries.GetList;

public class GetListFollowingListItemDto : IDto
{
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }
}