using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorModOperations.Queries.GetById;

public class GetByIdAuthorModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public int AuthorId { get; set; }
    public Guid ModOperationId { get; set; }
    public Guid? PenaltyId { get; set; }
}