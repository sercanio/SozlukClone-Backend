using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorBlockings.Queries.GetList;

public class GetListAuthorBlockingListItemDto : IDto
{
    public int BlockingId { get; set; }
    public int BlockerId { get; set; }
}