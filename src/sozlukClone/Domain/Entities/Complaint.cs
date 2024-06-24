using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Complaint : Entity<Guid>
{
    public int? TitleId { get; set; }
    public int? EntryId { get; set; }
    public string Details { get; set; }
    public ComplaintStatusEnum Status { get; set; } = ComplaintStatusEnum.Pending;
    public int? AuthorId { get; set; }
    public string? Email { get; set; }

    public virtual Author? Author { get; set; }
    public virtual Title? Title { get; set; }
    public virtual Entry? Entry { get; set; }
}
