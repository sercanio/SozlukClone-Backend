using NArchitecture.Core.Application.Responses;

namespace Application.Features.Badges.Commands.Delete;

public class DeletedBadgeResponse : IResponse
{
    public uint Id { get; set; }
}