using NArchitecture.Core.Application.Responses;

namespace Application.Features.EntryModOperations.Queries.GetById;

public class GetByIdEntryModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public Guid ModOperationId { get; set; }
}