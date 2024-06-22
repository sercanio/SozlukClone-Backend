using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleModOperations.Queries.GetById;

public class GetByIdTitleModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public int TitleId { get; set; }
}