using NArchitecture.Core.Application.Responses;

namespace Application.Features.PenaltyTypes.Commands.Delete;

public class DeletedPenaltyTypeResponse : IResponse
{
    public uint Id { get; set; }
}