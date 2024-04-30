using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AuthorGroupConfiguration : IEntityTypeConfiguration<AuthorGroup>
{
    public void Configure(EntityTypeBuilder<AuthorGroup> builder)
    {
        builder.ToTable("AuthorGroups").HasKey(ag => ag.Id);

        builder.Property(ag => ag.Id).HasColumnName("Id").IsRequired();
        builder.Property(ag => ag.Name).HasColumnName("Name").IsRequired();
        builder.Property(ag => ag.Description).HasColumnName("Description");
        builder.Property(ag => ag.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ag => ag.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ag => ag.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(ag => ag.Name).IsUnique();

        builder.HasData(_seeds);

        builder.HasQueryFilter(ag => !ag.DeletedDate.HasValue);
    }

    private IEnumerable<AuthorGroup> _seeds
    {
        get
        {
            return new List<AuthorGroup>
            {
                new AuthorGroup { Id = 1, Name = "Developer", Description = "Developer", CreatedDate = DateTime.Now},
                new AuthorGroup { Id = 2, Name = "SuperAdmin", Description = "SuperAdmin", CreatedDate = DateTime.Now},
                new AuthorGroup { Id = 3, Name = "Admin", Description = "Admin", CreatedDate = DateTime.Now },
                new AuthorGroup { Id = 4, Name = "SuperModerator", Description = "SuperModerator", CreatedDate = DateTime.Now},
                new AuthorGroup { Id = 5, Name = "Moderator", Description = "Moderator", CreatedDate = DateTime.Now},
                new AuthorGroup { Id = 6, Name = "Editor", Description = "Editor", CreatedDate = DateTime.Now},
                new AuthorGroup { Id = 7, Name = "Author", Description = "Author", CreatedDate = DateTime.Now },
                new AuthorGroup { Id = 8, Name = "Noob", Description = "Guest", CreatedDate = DateTime.Now},
                new AuthorGroup { Id = 9, Name = "Suspended", Description = "Suspended", CreatedDate = DateTime.Now},
                new AuthorGroup { Id = 10, Name = "Banned", Description = "Banned", CreatedDate = DateTime.Now},
            };
        }
    }
}