using NArchitecture.Core.Application.Responses;

namespace Application.Features.Followings.Commands.Delete;

public class DeletedFollowingResponse : IResponse
{
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }
}