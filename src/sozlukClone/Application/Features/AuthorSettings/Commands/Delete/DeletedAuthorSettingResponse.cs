using NArchitecture.Core.Application.Responses;

namespace Application.Features.AuthorSettings.Commands.Delete;

public class DeletedAuthorSettingResponse : IResponse
{
    public uint Id { get; set; }
}