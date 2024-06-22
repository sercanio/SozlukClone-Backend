using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorBlockingConfiguration : IEntityTypeConfiguration<AuthorBlocking>
{
    public void Configure(EntityTypeBuilder<AuthorBlocking> builder)
    {
        builder.ToTable("AuthorBlockings").HasKey(ab => ab.Id);

        builder.Property(ab => ab.Id).HasColumnName("Id").IsRequired();
        builder.Property(ab => ab.BlockerId).HasColumnName("BlockerId").IsRequired();
        builder.Property(ab => ab.BlockingId).HasColumnName("BlockingId").IsRequired();
        builder.Property(ab => ab.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ab => ab.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ab => ab.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ab => !ab.DeletedDate.HasValue);

        builder.HasOne(ab => ab.Blocker)
               .WithMany(a => a.Blockings)
               .HasForeignKey(ab => ab.BlockerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ab => ab.Blocking)
               .WithMany(a => a.Blockers)
               .HasForeignKey(ab => ab.BlockingId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}