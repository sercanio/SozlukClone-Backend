using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TitleModOperationConfiguration : IEntityTypeConfiguration<TitleModOperation>
{
    public void Configure(EntityTypeBuilder<TitleModOperation> builder)
    {
        builder.ToTable("TitleModOperations").HasKey(tmo => tmo.Id);

        builder.Property(tmo => tmo.Id).HasColumnName("Id").IsRequired();
        builder.Property(tmo => tmo.TitleId).HasColumnName("TitleId").IsRequired();
        builder.Property(tmo => tmo.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tmo => tmo.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tmo => tmo.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tmo => !tmo.DeletedDate.HasValue);
    }
}