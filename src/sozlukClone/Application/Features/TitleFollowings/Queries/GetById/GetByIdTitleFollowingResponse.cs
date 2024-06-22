using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleFollowings.Queries.GetById;

public class GetByIdTitleFollowingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}