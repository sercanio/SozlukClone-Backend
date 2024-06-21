using NArchitecture.Core.Application.Responses;

namespace Application.Features.Likes.Commands.Update;

public class UpdatedLikeResponse : IResponse
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public int AuthorId { get; set; }
}