using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Commands.Create;

public class CreatedTitleResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint AuthorId { get; set; }
    public bool IsLocked { get; set; }
}