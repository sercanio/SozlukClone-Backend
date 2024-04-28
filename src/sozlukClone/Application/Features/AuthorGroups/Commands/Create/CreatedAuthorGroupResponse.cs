using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroups.Commands.Create;

public class CreatedAuthorGroupResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}