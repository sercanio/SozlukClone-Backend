using NArchitecture.Core.Application.Responses;

namespace Application.Features.Followings.Commands.Update;

public class UpdatedFollowingResponse : IResponse
{
    public Guid Id { get; set; }
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }
}