using Application.Features.Authors.Queries.GetList;
using Application.Features.Entries.Queries.GetList;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Queries.GetBySlug;

public class GetTitleBySlugResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint AuthorId { get; set; }
    public bool IsLocked { get; set; }
    public string Slug { get; set; }

    public ICollection<GetListEntryInTitleListItemDTO> Entries { get; set; }
    public GetListAuthorInEntryListItemDto Author { get; set; }
}
