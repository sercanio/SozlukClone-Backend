using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorModOperations.Commands.Create;

public class CreatedAuthorModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public int AuthorId { get; set; }
    public Guid ModOperationId { get; set; }
    public Guid? PenaltyId { get; set; }
}