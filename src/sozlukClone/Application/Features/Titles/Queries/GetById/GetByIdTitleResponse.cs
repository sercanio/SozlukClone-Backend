using Application.Features.Entries.Queries.GetList;
using Application.Features.Entries.Queries.GetListEntryForHomePage;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Queries.GetById;

public class GetByIdTitleResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint AuthorId { get; set; }
    public bool IsLocked { get; set; }
    public string Slug { get; set; }

    public List<GetListEntryListItemDto> Entries { get; set; }
}