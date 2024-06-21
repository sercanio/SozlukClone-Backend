using NArchitecture.Core.Application.Responses;

namespace Application.Features.Dislikes.Commands.Create;

public class CreatedDislikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}