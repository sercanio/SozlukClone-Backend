using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.ToTable("Favorites").HasKey(f => f.Id);

        builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
        builder.Property(f => f.EntryId).HasColumnName("EntryId").IsRequired();
        builder.Property(f => f.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(f => !f.DeletedDate.HasValue);

        builder.HasOne(l => l.Entry)
           .WithMany(e => e.Favorites)
           .HasForeignKey(l => l.EntryId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(l => l.Author)
            .WithMany(a => a.Favorites)
            .HasForeignKey(l => l.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}