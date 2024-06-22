using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleBlockings.Commands.Create;

public class CreatedTitleBlockingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}