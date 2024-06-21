using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Favorite : Entity<Guid>
{
    public int EntryId { get; set; }
    public int AuthorId { get; set; }

    public virtual Entry Entry { get; set; }
    public virtual Author Author { get; set; }
}
