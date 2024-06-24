using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorBlockings.Commands.Create;

public class CreatedAuthorBlockingResponse : IResponse
{
    public Guid Id { get; set; }
    public int BlockingId { get; set; }
    public int BlockerId { get; set; }
}