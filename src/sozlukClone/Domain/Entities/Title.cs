using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Title : Entity<int>
{
    public string Name { get; set; }
    public int AuthorId { get; set; }
    public bool IsLocked { get; set; }
    public string Slug { get; set; }
    public virtual Author Author { get; set; }
    public ICollection<Category> Categories { get; set; }
    public virtual ICollection<Entry> Entries { get; set; }
    public virtual ICollection<TitleFollowing> Followers { get; set; }
    public virtual ICollection<TitleBlocking> Blockers { get; set; }
    public virtual ICollection<TitleModOperation> TitleModOperations { get; set; }
    public virtual ICollection<Complaint> Complaints { get; set; }
}
