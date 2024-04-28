using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroups.Commands.Update;

public class UpdatedAuthorGroupResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}