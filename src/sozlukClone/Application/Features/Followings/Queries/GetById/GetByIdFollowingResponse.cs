using NArchitecture.Core.Application.Responses;

namespace Application.Features.Followings.Queries.GetById;

public class GetByIdFollowingResponse : IResponse
{
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }
}