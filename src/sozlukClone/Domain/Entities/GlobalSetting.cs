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

    // Karma multipliers
    public decimal EntryMultiplier { get; set; } = 0.1M;
    public decimal TitleMultiplier { get; set; } = 0.2M;
    public decimal FollowingMultiplier { get; set; } = 0.01M;
    public decimal FollowerMultiplier { get; set; } = 1.0M;
    public decimal BlockingsMultiplier { get; set; } = -0.1M;
    public decimal BlockersMultiplier { get; set; } = -1.0M;
    public decimal GivenLikesMultiplier { get; set; } = 0.001M;
    public decimal GivenDislikesMultiplier { get; set; } = -0.001M;
    public decimal GivenFavoritesMultiplier { get; set; } = 0.002M;
    public decimal ReceivedLikesMultiplier { get; set; } = 0.01M;
    public decimal ReceivedDislikesMultiplier { get; set; } = -0.005M;
    public decimal ReceivedFavoritesMultiplier { get; set; } = 0.25M;
    public decimal FollowedTitlesMultiplier { get; set; } = 0.001M;
    public decimal BlockedTitlesMultiplier { get; set; } = -0.001M;
    public decimal ComplaintCountMultiplier { get; set; } = 0.0005M;
    public decimal ComplaintPendingCountMultiplier { get; set; } = 0.0M;
    public decimal ComplaintApprovedCountMultiplier { get; set; } = 0.001M;
    public decimal ComplaintRejectedCountMultiplier { get; set; } = -0.001M;
    public decimal ComplaintedEntriesMultiplier { get; set; } = -0.0001M;
    public decimal ComplaintedTitlesMultiplier { get; set; } = -0.0001M;
    public decimal BaseKarma { get; set; } = 0;

}
