using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorFollowings.Commands.Update;

public class UpdatedAuthorFollowingResponse : IResponse
{
    public Guid Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}