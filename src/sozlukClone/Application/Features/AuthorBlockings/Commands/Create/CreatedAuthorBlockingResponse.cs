using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorBlockings.Commands.Create;

public class CreatedAuthorBlockingResponse : IResponse
{
    public int BlockingId { get; set; }
    public int BlockerId { get; set; }
}