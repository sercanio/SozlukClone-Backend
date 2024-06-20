using Application.Features.Titles.Queries.GetList;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Entries.Queries.GetList;

public class GetListEntryListItemProfilePageDto : IDto
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    //public GetListAuthorListItemDto Author { get; set; }
    public GetListTitleListItemProfilePage Title { get; set; }
}