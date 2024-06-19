using Application.Features.Users.Queries.GetById;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Queries.GetById;

public class GetByIdAuthorForEntryResponse : IResponse
{
    public uint Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public uint AuthorGroupId { get; set; }
    public GetByIdUserInAuthorResponse User { get; set; }
}