using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AuthorModOperation : Entity<Guid>
{
    public string Name { get; set; }
    public int AuthorId { get; set; }
    public int IssuerId { get; set; }
    public Guid? PenaltyId { get; set; }

    public virtual Author Author { get; set; }
    public virtual Author Issuer { get; set; }
    public virtual Penalty? Penalty { get; set; }
}
