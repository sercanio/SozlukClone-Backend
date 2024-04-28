
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class PenaltyType : Entity<uint>
{
    public string Name { get; set; } // Uyari, Susturulma, Sureli Uzaklastirma, Ban
    public string Description { get; set; }
    public virtual ICollection<Penalty> Penalties { get; set; }
}
