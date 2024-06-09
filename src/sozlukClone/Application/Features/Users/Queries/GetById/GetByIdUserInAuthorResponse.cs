using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserInAuthorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public GetByIdUserInAuthorResponse()
    {

        Email = string.Empty;
    }

    public GetByIdUserInAuthorResponse(Guid id, string email, bool status)
    {
        Id = id;
        Email = email;
        Status = status;
    }
}
