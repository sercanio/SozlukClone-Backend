using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroupUserOperationClaims.Queries.GetById;

public class GetByIdAuthorGroupUserOperationClaimResponse : IResponse
{
    public Guid Id { get; set; }
    public int OperationClaimId { get; set; }
    public int AuthorGroupId { get; set; }
}