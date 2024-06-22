using NArchitecture.Core.Application.Responses;

namespace Application.Features.EntryModOperations.Commands.Delete;

public class DeletedEntryModOperationResponse : IResponse
{
    public Guid Id { get; set; }
}