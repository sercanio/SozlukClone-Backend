using Application.Features.Authors.Queries.GetById;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TitleModOperations.Queries.GetList;

public class GetListTitleModOperationListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual GetByIdAuthorForTitleGetByIdResponse Issuer { get; set; }
}