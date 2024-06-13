using Application.Features.Authors.Queries.GetList;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Entries.Queries.GetList;

public class GetListEntryInTitleListItemDTO : IDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public GetListAuthorInEntryListItemDto Author { get; set; }
}