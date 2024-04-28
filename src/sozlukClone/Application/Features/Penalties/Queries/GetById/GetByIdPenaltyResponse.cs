using NArchitecture.Core.Application.Responses;

namespace Application.Features.Penalties.Queries.GetById;

public class GetByIdPenaltyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public byte PenaltyTypeId { get; set; }
    public uint AuthorId { get; set; }
    public uint IssuerId { get; set; }
}