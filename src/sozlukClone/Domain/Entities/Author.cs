using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Author : Entity<uint>
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Biography { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string CoverPictureUrl { get; set; }
    public uint AuthorGroupId { get; set; }
    public uint ActiveBadgeId { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Badge>? Badges { get; set; }
    public virtual Badge ActiveBadge { get; set; }
    public virtual AuthorGroup AuthorGroup { get; set; }
    public virtual ICollection<Penalty> Penalties { get; set; }
}
