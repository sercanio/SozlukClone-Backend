using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TitleFollowings.Queries.GetList;

public class GetListTitleFollowingListItemDto : IDto
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}