using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorBlocking : Entity<Guid>
{
    public int BlockerId { get; set; }
    public int BlockingId { get; set; }

    public virtual Author Blocker { get; set; }
    public virtual Author Blocking { get; set; }
}
