using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TitleBlockings.Queries.GetList;

public class GetListTitleBlockingListItemDto : IDto
{
    public Guid Id { get; set; }
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}