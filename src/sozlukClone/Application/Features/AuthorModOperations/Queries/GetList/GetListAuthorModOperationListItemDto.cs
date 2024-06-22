using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorModOperations.Queries.GetList;

public class GetListAuthorModOperationListItemDto : IDto
{
    public Guid Id { get; set; }
    public int AuthorId { get; set; }
    public Guid ModOperationId { get; set; }
    public Guid? PenaltyId { get; set; }
}