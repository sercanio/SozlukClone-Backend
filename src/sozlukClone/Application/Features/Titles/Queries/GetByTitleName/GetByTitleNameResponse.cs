using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Queries.GetBySlug;

public class GetByTitleNameResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}
