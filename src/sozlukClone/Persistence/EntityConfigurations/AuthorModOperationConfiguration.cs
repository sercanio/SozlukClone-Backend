using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorModOperationConfiguration : IEntityTypeConfiguration<AuthorModOperation>
{
    public void Configure(EntityTypeBuilder<AuthorModOperation> builder)
    {
        builder.ToTable("AuthorModOperations").HasKey(amo => amo.Id);

        builder.Property(amo => amo.Id).HasColumnName("Id").IsRequired();
        builder.Property(amo => amo.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(amo => amo.PenaltyId).HasColumnName("PenaltyId");
        builder.Property(amo => amo.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(amo => amo.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(amo => amo.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(amo => !amo.DeletedDate.HasValue);
    }
}