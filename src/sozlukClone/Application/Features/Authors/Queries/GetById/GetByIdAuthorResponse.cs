using Application.Features.Titles.Queries.GetList;
using Application.Features.Users.Queries.GetById;
using Domain.Enums;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Queries.GetById;

public class GetByIdAuthorResponse : IResponse
{
    public uint Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string? Biography { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? CoverPictureUrl { get; set; }
    public byte? Age { get; set; }
    public Gender? Gender { get; set; }
    public uint AuthorGroupId { get; set; }
    public uint ActiveBadgeId { get; set; }
    public DateTime CreatedDate { get; set; }
    public GetByIdUserInAuthorResponse User { get; set; }
    public ICollection<GetListTitleListItemDto> Titles { get; set; }
}