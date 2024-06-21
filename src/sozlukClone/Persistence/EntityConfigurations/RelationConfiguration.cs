using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RelationConfiguration : IEntityTypeConfiguration<Relation>
{
    public void Configure(EntityTypeBuilder<Relation> builder)
    {
        builder.ToTable("Relations").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.FollowerId).HasColumnName("FollowerId").IsRequired();
        builder.Property(r => r.FollowingId).HasColumnName("FollowingId").IsRequired();
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);

        builder.HasOne(r => r.Follower)
               .WithMany(a => a.Followings)
               .HasForeignKey(r => r.FollowerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Following)
               .WithMany(a => a.Followers)
               .HasForeignKey(r => r.FollowingId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
