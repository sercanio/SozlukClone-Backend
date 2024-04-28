using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Penalties.Queries.GetList;

public class GetListPenaltyListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public byte PenaltyTypeId { get; set; }
    public uint AuthorId { get; set; }
    public uint IssuerId { get; set; }
}