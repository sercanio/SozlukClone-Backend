using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
{
    public void Configure(EntityTypeBuilder<Penalty> builder)
    {
        builder.ToTable("Penalties").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Reason).HasColumnName("Reason").IsRequired();
        builder.Property(p => p.StartDate).HasColumnName("StartDate").IsRequired();
        builder.Property(p => p.EndDate).HasColumnName("EndDate").IsRequired();
        builder.Property(p => p.PenaltyTypeId).HasColumnName("PenaltyTypeId").IsRequired();
        builder.Property(p => p.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(p => p.IssuerId).HasColumnName("IssuerId").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}