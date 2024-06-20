using Application.Features.Authors.Queries.GetList;
using Application.Features.Titles.Queries.GetList;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Queries.GetListByAuthorId;

public class GetListByAuthorIdResponse : IResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public GetListAuthorListItemDto Author { get; set; }
    public GetListTitleListItemInHomePageDto Title { get; set; }
}
