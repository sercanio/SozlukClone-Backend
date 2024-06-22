using NArchitecture.Core.Application.Responses;

namespace Application.Features.EntryModOperations.Commands.Update;

public class UpdatedEntryModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public Guid ModOperationId { get; set; }
}