using NArchitecture.Core.Application.Responses;

namespace Application.Features.Dislikes.Commands.Delete;

public class DeletedDislikeResponse : IResponse
{
    public Guid Id { get; set; }
}