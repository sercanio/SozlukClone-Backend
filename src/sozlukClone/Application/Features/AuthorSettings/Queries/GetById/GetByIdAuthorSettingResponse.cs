using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorSettings.Queries.GetById;

public class GetByIdAuthorSettingResponse : IResponse
{
    public uint Id { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string CoverPictureUrl { get; set; }
    public uint AuthorGroupId { get; set; }
    public uint ActiveBadgeId { get; set; }
}