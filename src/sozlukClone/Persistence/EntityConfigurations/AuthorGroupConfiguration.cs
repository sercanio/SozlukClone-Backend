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

        builder.HasData(_seeds());

        builder.HasQueryFilter(ag => !ag.DeletedDate.HasValue);
    }

    private IEnumerable<AuthorGroup> _seeds()
    {
        return new List<AuthorGroup>
        {
            new AuthorGroup { Id = 1, Name = "Developer", Description = "Developer"},
            new AuthorGroup { Id = 2, Name = "SuperAdmin", Description = "SuperAdmin"},
            new AuthorGroup { Id = 3, Name = "Admin", Description = "Admin" },
            new AuthorGroup { Id = 4, Name = "SuperModerator", Description = "SuperModerator" },
            new AuthorGroup { Id = 5, Name = "Moderator", Description = "Moderator" },
            new AuthorGroup { Id = 6, Name = "Editor", Description = "Editor" },
            new AuthorGroup { Id = 7, Name = "Author", Description = "Author" },
            new AuthorGroup { Id = 8, Name = "Noob", Description = "Guest" },
            new AuthorGroup { Id = 9, Name = "Suspended", Description = "Suspended" },
            new AuthorGroup { Id = 10, Name = "Banned", Description = "Banned" },
        };
    }
}