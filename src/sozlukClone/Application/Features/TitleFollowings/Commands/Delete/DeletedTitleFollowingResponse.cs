using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleFollowings.Commands.Delete;

public class DeletedTitleFollowingResponse : IResponse
{
    public Guid Id { get; set; }
}