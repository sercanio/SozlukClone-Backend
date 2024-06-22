using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorFollowings.Queries.GetById;

public class GetByIdAuthorFollowingResponse : IResponse
{
    public int FollowingId { get; set; }
    public int FollowerId { get; set; }
}