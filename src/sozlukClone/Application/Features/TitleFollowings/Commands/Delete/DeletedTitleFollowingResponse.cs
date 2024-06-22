using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleFollowings.Commands.Delete;

public class DeletedTitleFollowingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}