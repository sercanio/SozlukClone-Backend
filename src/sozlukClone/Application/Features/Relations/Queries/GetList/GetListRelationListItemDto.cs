using Application.Features.Authors.Queries.GetById;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Relations.Queries.GetList;

public class GetListRelationListItemDto : IDto
{
    public Guid Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }

    public GetByIdAuthorForEntryResponse Follower { get; set; }
    public GetByIdAuthorForEntryResponse Following { get; set; }
}