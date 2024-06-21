using NArchitecture.Core.Application.Responses;

namespace Application.Features.Dislikes.Queries.GetById;

public class GetByIdDislikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}