using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Commands.Delete;

public class DeletedAuthorResponse : IResponse
{
    public uint Id { get; set; }
}