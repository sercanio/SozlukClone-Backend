using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EntryModOperationConfiguration : IEntityTypeConfiguration<EntryModOperation>
{
    public void Configure(EntityTypeBuilder<EntryModOperation> builder)
    {
        builder.ToTable("EntryModOperations").HasKey(emo => emo.Id);

        builder.Property(emo => emo.Id).HasColumnName("Id").IsRequired();
        builder.Property(emo => emo.EntryId).HasColumnName("EntryId").IsRequired();
        builder.Property(emo => emo.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(emo => emo.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(emo => emo.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(emo => !emo.DeletedDate.HasValue);
    }
}