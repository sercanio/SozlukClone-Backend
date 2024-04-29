using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LoginAuditConfiguration : IEntityTypeConfiguration<LoginAudit>
{
    public void Configure(EntityTypeBuilder<LoginAudit> builder)
    {
        builder.ToTable("LoginAudits").HasKey(la => la.Id);

        builder.Property(la => la.Id).HasColumnName("Id").IsRequired();
        builder.Property(la => la.LastLoginIp).HasColumnName("LastLoginIp").IsRequired();
        builder.Property(la => la.LastLoginLocation).HasColumnName("LastLoginLocation").IsRequired();
        builder.Property(la => la.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(la => la.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(la => la.Username).HasColumnName("Username").IsRequired();
        builder.Property(la => la.Email).HasColumnName("Email").IsRequired();
        builder.Property(la => la.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(la => la.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(la => la.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(la => la.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(la => !la.DeletedDate.HasValue);
    }
}