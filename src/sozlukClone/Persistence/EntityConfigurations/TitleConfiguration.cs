using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Titles").HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
            builder.Property(t => t.AuthorId).HasColumnName("AuthorId").IsRequired();
            builder.Property(t => t.IsLocked).HasColumnName("IsLocked").IsRequired();
            builder.Property(t => t.Slug).HasColumnName("Slug").IsRequired();
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(t => t.Author)
                   .WithMany(a => a.Titles)
                   .HasForeignKey(t => t.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Entries)
                   .WithOne(e => e.Title)
                   .HasForeignKey(e => e.TitleId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Followers)
                   .WithOne(f => f.Title)
                   .HasForeignKey(f => f.TitleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.Blockers)
                    .WithOne(b => b.Title)
                    .HasForeignKey(b => b.TitleId)
                    .OnDelete(DeleteBehavior.Restrict);


            builder.HasQueryFilter(t => !t.DeletedDate.HasValue);

            builder.HasData(
                new Title
                {
                    Id = 1,
                    Name = "sozlukclone projesi",
                    AuthorId = 1,
                    IsLocked = false,
                    Slug = "sozluk-clone-1",
                    CreatedDate = DateTime.UtcNow
                }
            );
        }
    }
}
