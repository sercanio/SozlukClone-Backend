using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Penalty : Entity<Guid>
{
    public string Reason { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public byte PenaltyTypeId { get; set; }
    public int AuthorId { get; set; }
    public int IssuerId { get; set; }
    public virtual PenaltyType PenaltyType { get; set; }
}
