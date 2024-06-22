using NArchitecture.Core.Application.Dtos;

namespace Application.Features.EntryModOperations.Queries.GetList;

public class GetListEntryModOperationListItemDto : IDto
{
    public Guid Id { get; set; }
    public int EntryId { get; set; }
    public Guid ModOperationId { get; set; }
}