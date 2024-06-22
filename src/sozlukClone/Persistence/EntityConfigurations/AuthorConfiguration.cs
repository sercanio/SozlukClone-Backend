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
        builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(a => a.UserName).HasColumnName("UserName").IsRequired();
        builder.Property(a => a.Biography).HasColumnName("Biography");
        builder.Property(a => a.ProfilePictureUrl).HasColumnName("ProfilePictureUrl");
        builder.Property(a => a.CoverPictureUrl).HasColumnName("CoverPictureUrl");
        builder.Property(a => a.Age).HasColumnName("Age");
        builder.Property(a => a.Gender).HasColumnName("Gender");
        builder.Property(a => a.AuthorGroupId).HasColumnName("AuthorGroupId").IsRequired();
        builder.Property(a => a.ActiveBadgeId).HasColumnName("ActiveBadgeId").IsRequired();
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(a => a.UserId, "Author_UserID_UK").IsUnique();

        builder.HasOne(a => a.User);

        builder.HasOne(a => a.ActiveBadge)
               .WithMany()
               .HasForeignKey(a => a.ActiveBadgeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);

        builder.HasMany(a => a.Followers)
               .WithOne(r => r.Following)
               .HasForeignKey(r => r.FollowingId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(a => a.Followings)
               .WithOne(r => r.Follower)
               .HasForeignKey(r => r.FollowerId)
               .OnDelete(DeleteBehavior.Restrict);

        // Seed data
        builder.HasData(new Author
        {
            Id = 1,
            UserId = UserConfiguration.AdminId,
            UserName = "sozluk",
            AuthorGroupId = 1,
            ActiveBadgeId = 1,
            CreatedDate = DateTime.UtcNow,
        });
    }
}
