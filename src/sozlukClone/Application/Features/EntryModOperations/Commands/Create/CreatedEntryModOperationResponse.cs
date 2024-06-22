using NArchitecture.Core.Application.Responses;

namespace Application.Features.EntryModOperations.Commands.Create;

public class CreatedEntryModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public Guid ModOperationId { get; set; }
}