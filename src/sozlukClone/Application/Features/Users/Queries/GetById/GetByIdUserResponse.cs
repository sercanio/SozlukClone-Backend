using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public GetByIdUserResponse()
    {

        Email = string.Empty;
    }

    public GetByIdUserResponse(Guid id, string email, bool status)
    {
        Id = id;
        Email = email;
        Status = status;
    }
}
