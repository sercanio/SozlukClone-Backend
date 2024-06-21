using NArchitecture.Core.Application.Responses;

namespace Application.Features.Relations.Commands.Update;

public class UpdatedRelationResponse : IResponse
{
    public Guid Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}