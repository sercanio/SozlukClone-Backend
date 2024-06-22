using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleBlockings.Commands.Delete;

public class DeletedTitleBlockingResponse : IResponse
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }
}