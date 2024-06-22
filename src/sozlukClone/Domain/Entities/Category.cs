using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Category : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Title> Titles { get; set; }
}
