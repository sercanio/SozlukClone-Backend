using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorBlockings.Commands.Update;

public class UpdatedAuthorBlockingResponse : IResponse
{
    public int BlockingId { get; set; }
    public int BlockerId { get; set; }
}