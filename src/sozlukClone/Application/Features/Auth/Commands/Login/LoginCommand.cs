using Application.Features.Auth.Rules;
using Application.Services.AuthenticatorService;
using Application.Services.Authors;
using Application.Services.AuthService;
using Application.Services.LoginAudits;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Enums;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedResponse>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }

    public LoginCommand()
    {
        UserForLoginDto = null!;
        IpAddress = string.Empty;
    }

    public LoginCommand(UserForLoginDto userForLoginDto, string ipAddress)
    {
        UserForLoginDto = userForLoginDto;
        IpAddress = ipAddress;
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ILoginAuditService _loginAuditService;
        private readonly IAuthorService _authorService;

        public LoginCommandHandler(
            IUserService userService,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IAuthenticatorService authenticatorService
,
            ILoginAuditService loginAuditService,
            IAuthorService authorService)
        {
            _userService = userService;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _authenticatorService = authenticatorService;
            _loginAuditService = loginAuditService;
            _authorService = authorService;
        }

        public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Email == request.UserForLoginDto.Email,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.UserForLoginDto.Password);

            LoggedResponse loggedResponse = new();

            if (user!.AuthenticatorType is not AuthenticatorType.None)
            {
                if (request.UserForLoginDto.AuthenticatorCode is null)
                {
                    await _authenticatorService.SendAuthenticatorCode(user);
                    loggedResponse.RequiredAuthenticatorType = user.AuthenticatorType;
                    return loggedResponse;
                }

                await _authenticatorService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
            }

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            await _authService.DeleteOldRefreshTokens(user.Id);

            loggedResponse.AccessToken = createdAccessToken;
            loggedResponse.RefreshToken = addedRefreshToken;

            var author = await _authorService.GetAsync(predicate: a => a.UserId == user.Id);
            if (author != null)
            {

                var authorId = author.Id;
                var userName = author.UserName;

                LoginAudit authAudit = new()
                {
                    LastLoginIp = request.IpAddress,
                    LastLoginLocation = "",
                    UserId = user.Id,
                    AuthorId = authorId,
                    Username = userName,
                    Email = user.Email,
                    AuthenticatorType = user.AuthenticatorType
                };

                await _loginAuditService.AddAsync(authAudit);
            }

            return loggedResponse;
        }
    }
}
