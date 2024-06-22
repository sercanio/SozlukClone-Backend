using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorFollowing : Entity<Guid>
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }

    public virtual Author Follower { get; set; }
    public virtual Author Following { get; set; }
}
