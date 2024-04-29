using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RegisterAudits.Queries.GetList;

public class GetListRegisterAuditListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Ip { get; set; }
    public string Location { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
}