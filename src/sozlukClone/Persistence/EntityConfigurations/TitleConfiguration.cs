using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TitleConfiguration : IEntityTypeConfiguration<Title>
{
    public void Configure(EntityTypeBuilder<Title> builder)
    {
        builder.ToTable("Titles").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
        builder.Property(t => t.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(t => t.isLocked).HasColumnName("isLocked").IsRequired();
        builder.Property(t => t.slug).HasColumnName("slug").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasData(
            new Title { Id = 1, Name = "sozlukclone projesi", AuthorId = 1, isLocked = false, slug = "sozlukclone-1", CreatedDate = DateTime.UtcNow }
            );

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}