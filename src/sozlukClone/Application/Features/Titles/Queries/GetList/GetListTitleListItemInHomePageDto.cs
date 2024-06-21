using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Titles.Queries.GetList;

public class GetListTitleListItemProfilePage : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public int AuthorId { get; set; }
    public bool IsLocked { get; set; }
}