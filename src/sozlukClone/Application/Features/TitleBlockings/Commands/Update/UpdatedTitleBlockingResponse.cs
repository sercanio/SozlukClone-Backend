using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleBlockings.Commands.Update;

public class UpdatedTitleBlockingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}