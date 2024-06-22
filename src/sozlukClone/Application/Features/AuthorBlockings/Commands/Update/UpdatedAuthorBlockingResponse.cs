using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorBlockings.Commands.Update;

public class UpdatedAuthorBlockingResponse : IResponse
{
    public Guid Id { get; set; }
    public int BlockerId { get; set; }
    public int BlockingId { get; set; }
}