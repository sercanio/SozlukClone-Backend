using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EntryConfiguration : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        builder.ToTable("Entries").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Content).HasColumnName("Content").IsRequired();
        builder.Property(e => e.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(e => e.TitleId).HasColumnName("TitleId").IsRequired();
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        // Configure one-to-many relationships
        builder.HasMany(e => e.Likes)
               .WithOne(l => l.Entry)
               .HasForeignKey(l => l.EntryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Dislikes)
               .WithOne(d => d.Entry)
               .HasForeignKey(d => d.EntryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Favorites)
               .WithOne(f => f.Entry)
               .HasForeignKey(f => f.EntryId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);

        // Seed data
        builder.HasData(
            new Entry { Id = 1, Content = "ASP.Net ve Nextjs ile geliştirilmiş bir sözlük klonudur.", AuthorId = 1, TitleId = 1, CreatedDate = DateTime.UtcNow }
        );
    }
}
