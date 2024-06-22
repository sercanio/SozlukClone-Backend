using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleBlockings.Queries.GetById;

public class GetByIdTitleBlockingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}