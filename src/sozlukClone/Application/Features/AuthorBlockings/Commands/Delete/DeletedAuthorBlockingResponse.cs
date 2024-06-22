using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorBlockings.Commands.Delete;

public class DeletedAuthorBlockingResponse : IResponse
{
    public Guid Id { get; set; }
}