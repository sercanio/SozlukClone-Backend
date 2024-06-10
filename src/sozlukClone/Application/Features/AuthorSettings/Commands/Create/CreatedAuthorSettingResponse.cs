using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorSettings.Commands.Create;

public class CreatedAuthorSettingResponse : IResponse
{
    public uint Id { get; set; }
    public string ProfilePictureUrl { get; set; }
    public string CoverPictureUrl { get; set; }
    public uint ActiveBadgeId { get; set; }
}