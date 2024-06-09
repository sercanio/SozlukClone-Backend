using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorGroupConfiguration : IEntityTypeConfiguration<AuthorGroup>
{
    public void Configure(EntityTypeBuilder<AuthorGroup> builder)
    {
        builder.ToTable("AuthorGroups").HasKey(ag => ag.Id);

        builder.Property(ag => ag.Id).HasColumnName("Id").IsRequired();
        builder.Property(ag => ag.Name).HasColumnName("Name").IsRequired();
        builder.Property(ag => ag.Description).HasColumnName("Description");
        builder.Property(ag => ag.Color).HasColumnName("Color").IsRequired();
        builder.Property(ag => ag.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ag => ag.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ag => ag.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ag => !ag.DeletedDate.HasValue);
    }
}