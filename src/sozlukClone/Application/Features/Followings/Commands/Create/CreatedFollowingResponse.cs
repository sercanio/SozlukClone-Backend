using NArchitecture.Core.Application.Responses;

namespace Application.Features.Followings.Commands.Create;

public class CreatedFollowingResponse : IResponse
{
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }
}