using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleFollowings.Commands.Update;

public class UpdatedTitleFollowingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}