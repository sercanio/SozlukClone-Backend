using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PenaltyTypeConfiguration : IEntityTypeConfiguration<PenaltyType>
{
    public void Configure(EntityTypeBuilder<PenaltyType> builder)
    {
        builder.ToTable("PenaltyTypes").HasKey(pt => pt.Id);

        builder.Property(pt => pt.Id).HasColumnName("Id").IsRequired();
        builder.Property(pt => pt.Name).HasColumnName("Name").IsRequired();
        builder.Property(pt => pt.Description).HasColumnName("Description").IsRequired();
        builder.Property(pt => pt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pt => pt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pt => pt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pt => !pt.DeletedDate.HasValue);
    }
}