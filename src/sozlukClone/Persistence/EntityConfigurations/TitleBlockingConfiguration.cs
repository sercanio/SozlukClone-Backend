using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TitleBlockingConfiguration : IEntityTypeConfiguration<TitleBlocking>
{
    public void Configure(EntityTypeBuilder<TitleBlocking> builder)
    {
        builder.ToTable("TitleBlockings").HasKey(tb => tb.Id);

        builder.Property(tb => tb.Id).HasColumnName("Id").IsRequired();
        builder.Property(tb => tb.TitleId).HasColumnName("TitleId").IsRequired();
        builder.Property(tb => tb.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(tb => tb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tb => tb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tb => tb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tb => !tb.DeletedDate.HasValue);

        builder.Property(tb => tb.TitleId).IsRequired();
        builder.Property(tb => tb.AuthorId).IsRequired();

        builder.HasOne(tb => tb.Title)
               .WithMany(t => t.Blockers)
               .HasForeignKey(tb => tb.TitleId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tb => tb.Author)
               .WithMany(a => a.BlockedTitles)
               .HasForeignKey(tb => tb.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}