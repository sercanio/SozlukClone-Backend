using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class EntryModOperation : Entity<Guid>
{
    public string Name { get; set; }
    public int EntryId { get; set; }
    public int IssuerId { get; set; }

    public virtual Entry Entry { get; set; }
    public virtual Author Issuer { get; set; }
}
