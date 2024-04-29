using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Title : Entity<uint>
{
    public string Name { get; set; }
    public uint AuthorId { get; set; }
    public bool isLocked { get; set; } = false;
    public string slug { get; set; } = string.Empty;
    public virtual ICollection<Entry> Entries { get; set; }
    public virtual Author Author { get; set; }
}
