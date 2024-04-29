using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class RegisterAudit : Entity<Guid>
{
    public string Ip { get; set; }
    public string Location { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }

    public virtual User User { get; set; }
}
