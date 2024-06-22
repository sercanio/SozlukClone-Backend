using NArchitecture.Core.Application.Responses;

namespace Application.Features.Authors.Queries.GetById;

public class GetByIdAuthorForTitleGetByIdResponse : IResponse
{
    public int Id { get; set; }
    public string UserName { get; set; }
}