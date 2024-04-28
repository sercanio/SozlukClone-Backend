using NArchitecture.Core.Application.Responses;

namespace Application.Features.PenaltyTypes.Commands.Update;

public class UpdatedPenaltyTypeResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}