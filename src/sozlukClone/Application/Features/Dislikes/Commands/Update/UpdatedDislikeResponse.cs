using NArchitecture.Core.Application.Responses;

namespace Application.Features.Dislikes.Commands.Update;

public class UpdatedDislikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}