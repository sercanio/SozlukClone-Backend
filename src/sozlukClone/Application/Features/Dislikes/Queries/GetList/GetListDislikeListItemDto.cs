using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Dislikes.Queries.GetList;

public class GetListDislikeListItemDto : IDto
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}