using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorFollowings.Queries.GetById;

public class GetByIdAuthorFollowingResponse : IResponse
{
    public Guid Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}