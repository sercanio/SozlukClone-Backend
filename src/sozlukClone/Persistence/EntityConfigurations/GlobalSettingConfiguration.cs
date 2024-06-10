using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class GlobalSettingConfiguration : IEntityTypeConfiguration<GlobalSetting>
{
    public void Configure(EntityTypeBuilder<GlobalSetting> builder)
    {
        builder.ToTable("GlobalSettings").HasKey(gs => gs.Id);

        builder.Property(gs => gs.Id).HasColumnName("Id").IsRequired();
        builder.Property(gs => gs.SiteName).HasColumnName("SiteName");
        builder.Property(gs => gs.SiteDescription).HasColumnName("SiteDescription");
        builder.Property(gs => gs.SiteFavIcon).HasColumnName("SiteFavIcon");
        builder.Property(gs => gs.SiteLogo).HasColumnName("SiteLogo");
        builder.Property(gs => gs.SiteLogoFooter).HasColumnName("SiteLogoFooter");
        builder.Property(gs => gs.SiteLogoMobile).HasColumnName("SiteLogoMobile");
        builder.Property(gs => gs.MaxTitleLength).HasColumnName("MaxTitleLength");
        builder.Property(gs => gs.DefaultAuthorGroupId).HasColumnName("DefaultAuthorGroupId");
        builder.Property(gs => gs.IsAuthorRegistrationAllowed).HasColumnName("IsAuthorRegistrationAllowed");
        builder.Property(gs => gs.MaxEntryLength).HasColumnName("MaxEntryLength");
        builder.Property(gs => gs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gs => gs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gs => gs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gs => !gs.DeletedDate.HasValue);

        builder.HasData(
            new GlobalSetting
            {
                Id = 1,
                SiteName = "Default Site",
                SiteDescription = "Default Description",
                SiteFavIcon = "default-favicon.ico",
                SiteLogo = "default-logo.png",
                SiteLogoFooter = "default-footer-logo.png",
                SiteLogoMobile = "default-mobile-logo.png",
                MaxTitleLength = 50,
                DefaultAuthorGroupId = 8, // Noob
                IsAuthorRegistrationAllowed = true,
                MaxEntryLength = 5000,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = null,
                DeletedDate = null
            }
        );
    }
}
