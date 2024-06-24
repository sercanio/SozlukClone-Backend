using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Complaints.Commands.Update;

public class UpdatedComplaintResponse : IResponse
{
    public Guid Id { get; set; }
    public int TitleId { get; set; }
    public int? EntryId { get; set; }
    public string Details { get; set; }
    public ComplaintStatusEnum Status { get; set; }
    public int? AuthorId { get; set; }
    public string? Email { get; set; }
}