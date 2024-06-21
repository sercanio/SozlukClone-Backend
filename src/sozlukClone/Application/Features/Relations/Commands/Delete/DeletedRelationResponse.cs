using NArchitecture.Core.Application.Responses;

namespace Application.Features.Relations.Commands.Delete;

public class DeletedRelationResponse : IResponse
{
    public Guid Id { get; set; }
}