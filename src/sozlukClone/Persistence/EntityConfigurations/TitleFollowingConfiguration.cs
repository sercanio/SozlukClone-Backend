using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TitleFollowingConfiguration : IEntityTypeConfiguration<TitleFollowing>
{
    public void Configure(EntityTypeBuilder<TitleFollowing> builder)
    {
        builder.ToTable("TitleFollowings").HasKey(tf => tf.Id);

        builder.Property(tf => tf.Id).HasColumnName("Id").IsRequired();
        builder.Property(tf => tf.TitleId).HasColumnName("TitleId").IsRequired();
        builder.Property(tf => tf.AuthorId).HasColumnName("AuthorId").IsRequired();
        builder.Property(tf => tf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tf => tf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tf => tf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tf => !tf.DeletedDate.HasValue);

        builder.HasKey(tf => new { tf.TitleId, tf.AuthorId });

        builder.Property(tf => tf.TitleId).IsRequired();
        builder.Property(tf => tf.AuthorId).IsRequired();

        builder.HasOne(tf => tf.Title)
               .WithMany(t => t.Followers)
               .HasForeignKey(tf => tf.TitleId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(tf => tf.Author)
               .WithMany(a => a.FollowedTitles)
               .HasForeignKey(tf => tf.AuthorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}