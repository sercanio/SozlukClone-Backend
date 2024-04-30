using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Delete;

public class DeletedAuthorGroupUserOperationClaimResponse : IResponse
{
    public Guid Id { get; set; }
}