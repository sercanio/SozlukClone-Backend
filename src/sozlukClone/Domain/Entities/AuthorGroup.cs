using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorGroup : Entity<uint>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
}
