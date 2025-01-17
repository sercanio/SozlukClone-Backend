using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Commands.Update;

public class UpdatedTitleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AuthorId { get; set; }
    public bool IsLocked { get; set; }
    public string Slug { get; set; }
}