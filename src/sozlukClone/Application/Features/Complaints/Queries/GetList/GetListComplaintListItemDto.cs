using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Complaints.Queries.GetList;

public class GetListComplaintListItemDto : IDto
{
    public Guid Id { get; set; }
    public int TitleId { get; set; }
    public int? EntryId { get; set; }
    public string Details { get; set; }
    public ComplaintStatusEnum Status { get; set; }
    public int? AuthorId { get; set; }
    public string? Email { get; set; }
}