using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorModOperations.Commands.Delete;

public class DeletedAuthorModOperationResponse : IResponse
{
    public Guid Id { get; set; }
}