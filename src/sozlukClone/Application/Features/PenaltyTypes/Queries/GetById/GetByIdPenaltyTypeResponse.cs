using NArchitecture.Core.Application.Responses;

namespace Application.Features.PenaltyTypes.Queries.GetById;

public class GetByIdPenaltyTypeResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}