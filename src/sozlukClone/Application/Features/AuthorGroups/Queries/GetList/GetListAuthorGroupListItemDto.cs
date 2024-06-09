using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AuthorGroups.Queries.GetList;

public class GetListAuthorGroupListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Color { get; set; }
}