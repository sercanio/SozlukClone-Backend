using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Queries.GetById;

public class GetByIdEntryResponse : IResponse
{
    public uint Id { get; set; }
    public string Content { get; set; }
    public uint AuthorId { get; set; }
    public uint TitleId { get; set; }
}