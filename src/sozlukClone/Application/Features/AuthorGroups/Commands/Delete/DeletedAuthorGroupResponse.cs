using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroups.Commands.Delete;

public class DeletedAuthorGroupResponse : IResponse
{
    public uint Id { get; set; }
}