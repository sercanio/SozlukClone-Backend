using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorBlockings.Commands.Delete;

public class DeletedAuthorBlockingResponse : IResponse
{
    public int BlockingId { get; set; }
    public int BlockerId { get; set; }
}