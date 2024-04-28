using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Following : Entity<Guid>
{
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }

    public virtual Author Follower { get; set; }
    public virtual Author Followed { get; set; }
}