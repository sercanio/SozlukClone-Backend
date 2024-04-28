using NArchitecture.Core.Application.Responses;

namespace Application.Features.PenaltyTypes.Commands.Create;

public class CreatedPenaltyTypeResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}