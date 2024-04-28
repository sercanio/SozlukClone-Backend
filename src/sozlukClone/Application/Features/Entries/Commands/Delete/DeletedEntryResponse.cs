using NArchitecture.Core.Application.Responses;

namespace Application.Features.Entries.Commands.Delete;

public class DeletedEntryResponse : IResponse
{
    public uint Id { get; set; }
}