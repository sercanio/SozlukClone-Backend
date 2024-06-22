using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorFollowings.Commands.Create;

public class CreatedAuthorFollowingResponse : IResponse
{
    public int FollowingId { get; set; }
    public int FollowerId { get; set; }
}