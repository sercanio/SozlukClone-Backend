using NArchitecture.Core.Application.Responses;

namespace Application.Features.GlobalSettings.Commands.Delete;

public class DeletedGlobalSettingResponse : IResponse
{
    public int Id { get; set; }
}