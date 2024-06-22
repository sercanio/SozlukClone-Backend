using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class TitleModOperation : Entity<Guid>
{
    public string Name { get; set; }
    public int TitleId { get; set; }
    public int IssuerId { get; set; }

    public virtual Title Title { get; set; }
    public virtual Author Issuer { get; set; }
}
