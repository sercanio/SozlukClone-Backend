using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Badges.Queries.GetList;

public class GetListBadgeListItemDto : IDto
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}