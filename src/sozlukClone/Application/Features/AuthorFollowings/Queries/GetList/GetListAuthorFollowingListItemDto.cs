using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorFollowings.Queries.GetList;

public class GetListAuthorFollowingListItemDto : IDto
{
    public Guid Id { get; set; }
    public int FollowingId { get; set; }
    public int FollowerId { get; set; }
}