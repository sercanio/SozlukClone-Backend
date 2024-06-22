using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TitleBlockings.Queries.GetList;

public class GetListTitleBlockingListItemDto : IDto
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}