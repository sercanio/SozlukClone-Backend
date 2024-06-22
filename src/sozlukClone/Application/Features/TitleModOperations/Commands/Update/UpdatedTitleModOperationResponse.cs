using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleModOperations.Commands.Update;

public class UpdatedTitleModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public int TitleId { get; set; }

}