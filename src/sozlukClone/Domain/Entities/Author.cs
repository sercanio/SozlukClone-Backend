using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Author : Entity<int>
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string? Biography { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public string? CoverPictureUrl { get; set; }
    public byte? Age { get; set; }
    public GenderEnum? Gender { get; set; }
    public int AuthorGroupId { get; set; }
    public int ActiveBadgeId { get; set; }

    public virtual User User { get; set; }
    public virtual Badge ActiveBadge { get; set; }
    public virtual AuthorGroup AuthorGroup { get; set; }
    public virtual ICollection<Badge> Badges { get; set; }
    public virtual ICollection<Penalty> Penalties { get; set; }
    public virtual ICollection<Entry> Entries { get; set; }
    public virtual ICollection<Title> Titles { get; set; }
    public virtual ICollection<LoginAudit> LoginAudits { get; set; }
    public virtual ICollection<AuthorFollowing> Followers { get; set; }
    public virtual ICollection<AuthorFollowing> Followings { get; set; }
    public virtual ICollection<AuthorBlocking> Blockers { get; set; }
    public virtual ICollection<AuthorBlocking> Blockings { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<Dislike> Dislikes { get; set; }
    public virtual ICollection<Favorite> Favorites { get; set; }
    public virtual ICollection<TitleFollowing> FollowedTitles { get; set; }
    public virtual ICollection<TitleBlocking> BlockedTitles { get; set; }
}
