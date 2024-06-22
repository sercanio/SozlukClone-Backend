using Application.Features.Authors.Queries.GetById;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Queries.GetBySlug;

public class GetTitleBySlugResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsLocked { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public GetByIdAuthorForTitleGetByIdResponse Author { get; set; }
}
