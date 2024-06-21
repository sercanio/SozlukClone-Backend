using NArchitecture.Core.Application.Responses;

namespace Application.Features.Relations.Queries.GetById;

public class GetByIdRelationResponse : IResponse
{
    public Guid Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}