using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.GlobalSettings.Queries.GetList;

public class GetListGlobalSettingListItemDto : IDto
{
    public int Id { get; set; }
    public string? SiteName { get; set; }
    public string? SiteDescription { get; set; }
    public string? SiteFavIcon { get; set; }
    public string? SiteLogo { get; set; }
    public string? SiteLogoFooter { get; set; }
    public string? SiteLogoMobile { get; set; }
    public int? MaxTitleLength { get; set; }
    public int? DefaultAuthorGroupId { get; set; }
    public AuthorGroup? DefaultAuthorGroup { get; set; }
    public bool? IsAuthorRegistrationAllowed { get; set; }
    public int? MaxEntryLength { get; set; }
}