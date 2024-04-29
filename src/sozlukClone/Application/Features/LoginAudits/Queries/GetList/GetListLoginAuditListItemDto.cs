using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Enums;

namespace Application.Features.LoginAudits.Queries.GetList;

public class GetListLoginAuditListItemDto : IDto
{
    public Guid Id { get; set; }
    public string LastLoginIp { get; set; }
    public string LastLoginLocation { get; set; }
    public Guid UserId { get; set; }
    public uint AuthorId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }
}