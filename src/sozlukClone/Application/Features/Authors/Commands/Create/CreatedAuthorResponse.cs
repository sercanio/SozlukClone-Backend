using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Commands.Create;

public class CreatedAuthorResponse : IResponse
{
    public uint Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Biography { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string CoverPictureUrl { get; set; }
    public uint AuthorGroupId { get; set; }
    public uint ActiveBadgeId { get; set; }
}