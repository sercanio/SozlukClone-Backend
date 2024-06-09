using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroups.Commands.Delete;

public class DeletedAuthorGroupResponse : IResponse
{
    public int Id { get; set; }
}