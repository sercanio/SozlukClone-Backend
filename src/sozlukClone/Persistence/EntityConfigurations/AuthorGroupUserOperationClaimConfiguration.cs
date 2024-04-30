using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorGroupUserOperationClaimConfiguration : IEntityTypeConfiguration<AuthorGroupUserOperationClaim>
{
    public void Configure(EntityTypeBuilder<AuthorGroupUserOperationClaim> builder)
    {
        builder.ToTable("AuthorGroupUserOperationClaims").HasKey(aguoc => aguoc.Id);

        builder.Property(aguoc => aguoc.Id).HasColumnName("Id").IsRequired();
        builder.Property(aguoc => aguoc.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();
        builder.Property(aguoc => aguoc.AuthorGroupId).HasColumnName("AuthorGroupId").IsRequired();
        builder.Property(aguoc => aguoc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(aguoc => aguoc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(aguoc => aguoc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(aguoc => aguoc.AuthorGroup);
        builder.HasOne(aguoc => aguoc.OperationClaim);


        builder.HasQueryFilter(aguoc => !aguoc.DeletedDate.HasValue);
    }
}