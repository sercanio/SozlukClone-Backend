using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Commands.Create;

public class CreatedEntryResponse : IResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; }
    public int TitleId { get; set; }

    public Author Author { get; set; }
    public Title Title { get; set; }
}