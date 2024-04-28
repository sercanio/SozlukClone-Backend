using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Commands.Update;

public class UpdatedEntryResponse : IResponse
{
    public uint Id { get; set; }
    public string Content { get; set; }
    public uint AuthorId { get; set; }
    public uint TitleId { get; set; }
}