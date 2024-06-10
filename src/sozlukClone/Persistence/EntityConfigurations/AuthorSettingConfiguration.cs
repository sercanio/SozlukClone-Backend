using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorSettingConfiguration : IEntityTypeConfiguration<AuthorSetting>
{
    public void Configure(EntityTypeBuilder<AuthorSetting> builder)
    {
        builder.ToTable("AuthorSettings").HasKey(ast => ast.Id);

        builder.Property(ast => ast.Id).HasColumnName("Id").IsRequired();
        builder.Property(ast => ast.ProfilePictureUrl).HasColumnName("ProfilePictureUrl").IsRequired();
        builder.Property(ast => ast.CoverPictureUrl).HasColumnName("CoverPictureUrl").IsRequired();
        builder.Property(ast => ast.ActiveBadgeId).HasColumnName("ActiveBadgeId").IsRequired();
        builder.Property(ast => ast.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ast => ast.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ast => ast.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(_seeds());

        builder.HasQueryFilter(ast => !ast.DeletedDate.HasValue);
    }

    private IEnumerable<AuthorSetting> _seeds()
    {
        return new List<AuthorSetting>
        {
            new AuthorSetting { Id = 1, ProfilePictureUrl = "default-profile.png", CoverPictureUrl = "default-cover.png", ActiveBadgeId = 1 },
        };
    }
}