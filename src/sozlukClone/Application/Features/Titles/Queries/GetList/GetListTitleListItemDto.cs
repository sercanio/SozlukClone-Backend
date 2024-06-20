using Application.Features.Entries.Queries.GetList;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Titles.Queries.GetList;

public class GetListTitleListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int EntryCount { get; set; }

    public ICollection<GetListEntryInTitleListItemDTO> Entries { get; set; }
}