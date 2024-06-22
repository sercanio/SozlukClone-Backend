using Application.Features.Authors.Queries.GetList;
using Application.Features.Titles.Queries.GetList;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.TitleModOperations.Commands.Create;

public class CreatedTitleModOperationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int TitleId { get; set; }
    public int IssuerId { get; set; }

    public virtual GetListTitleListItemDto Title { get; set; }
    public virtual GetListAuthorListItemDto Issuer { get; set; }
}