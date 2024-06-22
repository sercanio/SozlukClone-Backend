using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorFollowings.Commands.Delete;

public class DeletedAuthorFollowingResponse : IResponse
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}