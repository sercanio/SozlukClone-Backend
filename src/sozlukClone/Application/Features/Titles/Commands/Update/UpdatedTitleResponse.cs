using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Commands.Update;

public class UpdatedTitleResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public uint AuthorId { get; set; }
    public bool IsLocked { get; set; }
}