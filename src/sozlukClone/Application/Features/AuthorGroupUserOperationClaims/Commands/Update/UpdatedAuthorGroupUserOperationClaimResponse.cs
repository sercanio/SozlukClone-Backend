using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Update;

public class UpdatedAuthorGroupUserOperationClaimResponse : IResponse
{
    public Guid Id { get; set; }
    public int OperationClaimId { get; set; }
    public int AuthorGroupId { get; set; }
}