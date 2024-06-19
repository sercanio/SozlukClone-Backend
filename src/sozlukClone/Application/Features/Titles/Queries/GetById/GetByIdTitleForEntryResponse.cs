using NArchitecture.Core.Application.Responses;

namespace Application.Features.Titles.Queries.GetById;

public class GetByIdTitleForEntryResponse : IResponse
{
    public uint Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public bool IsLocked { get; set; }
}