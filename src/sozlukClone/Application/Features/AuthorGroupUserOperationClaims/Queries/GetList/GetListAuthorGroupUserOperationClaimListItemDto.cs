using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorGroupUserOperationClaims.Queries.GetList;

public class GetListAuthorGroupUserOperationClaimListItemDto : IDto
{
    public Guid Id { get; set; }
    public int OperationClaimId { get; set; }
    public int AuthorGroupId { get; set; }
}