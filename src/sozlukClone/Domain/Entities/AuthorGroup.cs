using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorGroup : Entity<int>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Color { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<AuthorGroupUserOperationClaim> AuthorGroupUserOperationClaim { get; set; }
}
