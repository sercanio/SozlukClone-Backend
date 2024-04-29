using NArchitecture.Core.Application.Responses;

namespace Application.Features.RegisterAudits.Queries.GetById;

public class GetByIdRegisterAuditResponse : IResponse
{
    public Guid Id { get; set; }
    public string Ip { get; set; }
    public string Location { get; set; }
    public Guid UserId { get; set; }
    public string Email { get; set; }
}