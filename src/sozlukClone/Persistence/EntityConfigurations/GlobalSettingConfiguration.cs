using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

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
        builder.Property(gs => gs.DefaultAuthorGroup).HasColumnName("DefaultAuthorGroup");
        builder.Property(gs => gs.IsAuthorRegistrationAllowed).HasColumnName("IsAuthorRegistrationAllowed");
        builder.Property(gs => gs.MaxEntryLength).HasColumnName("MaxEntryLength");
        builder.Property(gs => gs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(gs => gs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(gs => gs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(gs => !gs.DeletedDate.HasValue);

        builder.Property(gs => gs.DefaultAuthorGroupId).HasColumnName("DefaultAuthorGroupId");
        builder.Property(gs => gs.DefaultAuthorGroup).HasColumnName("DefaultAuthorGroup")
            .HasConversion(
                v => JsonConvert.SerializeObject(v), 
                v => JsonConvert.DeserializeObject<AuthorGroup>(v) 
            );

        // Seed data
        builder.HasData(
            new GlobalSetting
            {
                Id = 1,
                SiteName = "SozlukClone",
                SiteDescription = "?çsel Bilgi Kayna??",
                SiteFavIcon = "favicon.ico",
                SiteLogo = "logo.png",
                SiteLogoFooter = "footer-logo.png",
                SiteLogoMobile = "mobile-logo.png",
                MaxTitleLength = 200,
                DefaultAuthorGroupId = 10, // Noobs
                IsAuthorRegistrationAllowed = true,
                MaxEntryLength = 5000,
            }
        );
    }
}
