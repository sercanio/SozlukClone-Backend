using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public CreatedUserResponse()
    {
        Email = string.Empty;
    }

    public CreatedUserResponse(Guid id, string email, bool status)
    {
        Id = id;
        Email = email;
        Status = status;
    }
}
