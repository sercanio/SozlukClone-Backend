using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Entries.Queries.GetList;

public class GetListEntryListItemDto : IDto
{
    public uint Id { get; set; }
    public string Content { get; set; }
    public uint AuthorId { get; set; }
    public uint TitleId { get; set; }
}