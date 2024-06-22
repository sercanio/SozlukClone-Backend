using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleModOperations.Commands.Delete;

public class DeletedTitleModOperationResponse : IResponse
{
    public Guid Id { get; set; }
}