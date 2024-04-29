using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Titles.Queries.GetList;

public class GetListTitleListItemDto : IDto
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}