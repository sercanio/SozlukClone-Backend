using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RegisterAuditConfiguration : IEntityTypeConfiguration<RegisterAudit>
{
    public void Configure(EntityTypeBuilder<RegisterAudit> builder)
    {
        builder.ToTable("RegisterAudits").HasKey(ra => ra.Id);

        builder.Property(ra => ra.Id).HasColumnName("Id").IsRequired();
        builder.Property(ra => ra.Ip).HasColumnName("Ip").IsRequired();
        builder.Property(ra => ra.Location).HasColumnName("Location").IsRequired();
        builder.Property(ra => ra.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(ra => ra.Email).HasColumnName("Email").IsRequired();
        builder.Property(ra => ra.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ra => ra.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ra => ra.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ra => !ra.DeletedDate.HasValue);
    }
}