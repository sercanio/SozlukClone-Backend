using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Queries.GetById;

public class GetByIdEntryResponse : IResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }
}