using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TitleFollowings.Queries.GetList;

public class GetListTitleFollowingListItemDto : IDto
{
    public Guid Id { get; set; }
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}