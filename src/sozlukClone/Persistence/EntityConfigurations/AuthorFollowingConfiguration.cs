using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorFollowingConfiguration : IEntityTypeConfiguration<AuthorFollowing>
{
    public void Configure(EntityTypeBuilder<AuthorFollowing> builder)
    {
        builder.ToTable("AuthorFollowings").HasKey(af => af.Id);

        builder.Property(af => af.Id).HasColumnName("Id").IsRequired();
        builder.Property(af => af.FollowerId).HasColumnName("FollowerId").IsRequired();
        builder.Property(af => af.FollowingId).HasColumnName("FollowingId").IsRequired();
        builder.Property(af => af.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(af => af.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(af => af.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(af => !af.DeletedDate.HasValue);

        builder.Property(af => af.FollowerId).IsRequired();
        builder.Property(af => af.FollowingId).IsRequired();

        builder.HasOne(af => af.Follower)
               .WithMany(a => a.Followings)
               .HasForeignKey(af => af.FollowerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(af => af.Following)
               .WithMany(a => a.Followers)
               .HasForeignKey(af => af.FollowingId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}