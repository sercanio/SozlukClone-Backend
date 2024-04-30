using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.ToTable("Badges").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
        builder.Property(b => b.IconUrl).HasColumnName("IconUrl").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(b => b.Name).IsUnique();

        builder.HasData(_seeds());

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }

    private IEnumerable<Badge> _seeds()
    {
        return new List<Badge>
            {
                new Badge { Id = 1, Name = "Default", Description = "Default", IconUrl = "https://localhost:5001/images/badges/rookie.png"},

            };
    }
}