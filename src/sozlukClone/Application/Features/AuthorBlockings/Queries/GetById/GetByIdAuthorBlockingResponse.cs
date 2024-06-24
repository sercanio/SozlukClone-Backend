using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorBlockings.Queries.GetById;

public class GetByIdAuthorBlockingResponse : IResponse
{
    public Guid Id { get; set; }
    public int BlockingId { get; set; }
    public int BlockerId { get; set; }
}