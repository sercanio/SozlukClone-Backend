using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorBlockings.Queries.GetList;

public class GetListAuthorBlockingListItemDto : IDto
{
    public Guid Id { get; set; }
    public int BlockerId { get; set; }
    public int BlockingId { get; set; }
}