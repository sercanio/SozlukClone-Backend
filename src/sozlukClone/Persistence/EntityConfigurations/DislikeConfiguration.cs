using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DislikeConfiguration : IEntityTypeConfiguration<Dislike>
{
    public void Configure(EntityTypeBuilder<Dislike> builder)
    {
        builder.ToTable("Dislikes").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.EntryId).HasColumnName("EntryId").IsRequired();
        builder.Property(d => d.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}