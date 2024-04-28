using NArchitecture.Core.Application.Responses;

namespace Application.Features.Badges.Queries.GetById;

public class GetByIdBadgeResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}