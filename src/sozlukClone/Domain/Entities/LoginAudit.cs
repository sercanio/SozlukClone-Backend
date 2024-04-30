using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Enums;

namespace Domain.Entities;
public class LoginAudit : Entity<Guid>
{
    public string LastLoginIp { get; set; }
    public string LastLoginLocation { get; set; }
    public Guid UserId { get; set; }
    public int AuthorId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual User User { get; set; }
    public virtual Author Author { get; set; }

}
