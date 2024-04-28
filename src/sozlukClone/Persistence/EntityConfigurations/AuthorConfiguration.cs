using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(a => a.Biography).HasColumnName("Biography").IsRequired();
        builder.Property(a => a.ProfilePictureUrl).HasColumnName("ProfilePictureUrl").IsRequired();
        builder.Property(a => a.CoverPictureUrl).HasColumnName("CoverPictureUrl").IsRequired();
        builder.Property(a => a.AuthorGroupId).HasColumnName("AuthorGroupId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        // Make 1-1 relationship between Author and User
        builder.HasIndex(indexExpression: a => a.UserId, name: "Author_UserID_UK").IsUnique();
        builder.HasOne(a => a.User);

        builder.HasOne(a => a.ActiveBadge)
               .WithMany()
               .HasForeignKey(a => a.ActiveBadgeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
