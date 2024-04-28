using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Users.Commands.UpdateFromAuth;

public class UpdatedUserFromAuthResponse : IResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public AccessToken AccessToken { get; set; }

    public UpdatedUserFromAuthResponse()
    {
        Email = string.Empty;
        AccessToken = null!;
    }

    public UpdatedUserFromAuthResponse(Guid id, string email, AccessToken accessToken)
    {
        Id = id;
        Email = email;
        AccessToken = accessToken;
    }
}
