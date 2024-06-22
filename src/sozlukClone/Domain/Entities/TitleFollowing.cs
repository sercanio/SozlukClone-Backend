using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class TitleFollowing : Entity<Guid>
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }

    public virtual Title Title { get; set; }
    public virtual Author Author { get; set; }
}
