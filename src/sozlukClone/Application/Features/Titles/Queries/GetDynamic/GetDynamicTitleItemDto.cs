using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Titles.Queries.GetDynamic;
public class GetDynamicTitleItemDto : IDto
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}
