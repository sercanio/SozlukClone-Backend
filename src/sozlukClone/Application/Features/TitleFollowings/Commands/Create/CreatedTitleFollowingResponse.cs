using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleFollowings.Commands.Create;

public class CreatedTitleFollowingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}