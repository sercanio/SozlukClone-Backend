using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PenaltyTypes.Queries.GetList;

public class GetListPenaltyTypeListItemDto : IDto
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}