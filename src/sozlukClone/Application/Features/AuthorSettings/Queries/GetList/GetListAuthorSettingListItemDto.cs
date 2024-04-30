using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorSettings.Queries.GetList;

public class GetListAuthorSettingListItemDto : IDto
{
    public uint Id { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string CoverPictureUrl { get; set; }
    public uint AuthorGroupId { get; set; }
    public uint ActiveBadgeId { get; set; }
}