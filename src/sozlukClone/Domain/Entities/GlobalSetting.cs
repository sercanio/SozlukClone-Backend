using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class GlobalSetting : Entity<int>
{
    // Global settings
    public string? SiteName { get; set; }
    public string? SiteDescription { get; set; }
    public string? SiteFavIcon { get; set; }
    public string? SiteLogo { get; set; }
    public string? SiteLogoFooter { get; set; }
    public string? SiteLogoMobile { get; set; }

    // Title Settings
    public int? MaxTitleLength { get; set; }

    // Author Settings
    public int DefaultAuthorGroupId { get; set; }
    public AuthorGroup? DefaultAuthorGroup { get; set; }
    public bool? IsAuthorRegistrationAllowed { get; set; } = true;

    // Entry Settings
    public int? MaxEntryLength { get; set; }
}
