using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroups.Queries.GetById;

public class GetByIdAuthorGroupResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}