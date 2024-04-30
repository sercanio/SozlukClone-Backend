using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Entry : Entity<int>
{
    public string Content { get; set; }
    public uint AuthorId { get; set; }
    public uint TitleId { get; set; }

    public virtual Author Author { get; set; }
    public virtual Title Title { get; set; }

}
