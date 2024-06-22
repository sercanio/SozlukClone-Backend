using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorFollowings.Commands.Delete;

public class DeletedAuthorFollowingResponse : IResponse
{
    public Guid Id { get; set; }
}