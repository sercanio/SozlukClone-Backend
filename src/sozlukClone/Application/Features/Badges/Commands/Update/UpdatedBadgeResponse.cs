using NArchitecture.Core.Application.Responses;

namespace Application.Features.Badges.Commands.Update;

public class UpdatedBadgeResponse : IResponse
{
    public uint Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string IconUrl { get; set; }
}