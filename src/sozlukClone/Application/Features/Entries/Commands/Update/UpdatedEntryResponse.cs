using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Commands.Update;

public class UpdatedEntryResponse : IResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }
}