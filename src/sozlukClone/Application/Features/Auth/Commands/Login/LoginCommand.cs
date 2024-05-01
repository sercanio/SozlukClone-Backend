using Application.Features.Auth.Rules;
using Application.Services.AuthenticatorService;
using Application.Services.AuthorGroupUserOperationClaims;
using Application.Services.Authors;
using Application.Services.AuthService;
using Application.Services.LoginAudits;
using Application.Services.UserOperationClaims;
using Application.Services.UsersService;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Persistence.Paging;
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
        private readonly IAuthorGroupUserOperationClaimService _authorGroupUserOperationClaimService;
        private readonly IUserOperationClaimService _userOperationClaimService;

        public LoginCommandHandler(IUserService userService1, IAuthService authService1, AuthBusinessRules authBusinessRules1, IAuthenticatorService authententicatorService, ILoginAuditService loginAuditService1, IAuthorService authorService1, IAuthorGroupUserOperationClaimService authorGroupUserOperationClaimService1)
        {
            UserService = userService1;
            AuthService = authService1;
            AuthBusinessRules = authBusinessRules1;
            AuthententicatorService = authententicatorService;
            LoginAuditService = loginAuditService1;
            AuthorService = authorService1;
            AuthorGroupUserOperationClaimService = authorGroupUserOperationClaimService1;
        }

        public LoginCommandHandler(
            IUserService userService,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IAuthenticatorService authenticatorService
,
            ILoginAuditService loginAuditService,
            IAuthorService authorService,
            IAuthorGroupUserOperationClaimService authorGroupUserOperationClaimService,
            IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _authenticatorService = authenticatorService;
            _loginAuditService = loginAuditService;
            _authorService = authorService;
            _authorGroupUserOperationClaimService = authorGroupUserOperationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }

        public IUserService UserService { get; }
        public IAuthService AuthService { get; }
        public AuthBusinessRules AuthBusinessRules { get; }
        public IAuthenticatorService AuthententicatorService { get; }
        public ILoginAuditService LoginAuditService { get; }
        public IAuthorService AuthorService { get; }
        public IAuthorGroupUserOperationClaimService AuthorGroupUserOperationClaimService { get; }

        public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Email == request.UserForLoginDto.Email,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.UserForLoginDto.Password);

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

                // Get AuthorGroupUserOperationClaims and add to UserOperationClaims 
                // tl;dr : Add author's operation claims to user to give role based permissions
                var authorGroupId = author.AuthorGroupId;

                #region Get AuthorGroupUserOperationClaims Count
                IPaginate<AuthorGroupUserOperationClaim>? claims = await _authorGroupUserOperationClaimService.GetListAsync(
                    predicate: aguoc => aguoc.AuthorGroupId == authorGroupId, index: 0, size: 0);
                if (claims == null)
                    throw new Exception("AuthorGroupUserOperationClaims not found");

                int total = claims.Count;
                #endregion

                #region get AuthorGroupOperationClaims
                IPaginate<AuthorGroupUserOperationClaim>? authorGroupUserOperationClaims = await _authorGroupUserOperationClaimService.GetListAsync(
                    predicate: aguoc => aguoc.AuthorGroupId == authorGroupId, index: 0, size: total);
                #endregion

                #region Get UserOperationClaims Count
                IPaginate<UserOperationClaim>? OperationClaims = await _userOperationClaimService.GetListAsync(
                    predicate: uoc => uoc.UserId == user.Id,
                    index: 0, size: 0,
                    cancellationToken: cancellationToken
                    );

                if (OperationClaims == null)
                    throw new Exception("UserOperationClaims not found");

                int totalUserOperationClaims = OperationClaims.Count;
                #endregion

                #region Get UserOperationClaims
                IPaginate<UserOperationClaim>? userOperationClaims = await _userOperationClaimService.GetListAsync(
                    predicate: uoc => uoc.UserId == user.Id,
                    index: 0, size: totalUserOperationClaims,
                    cancellationToken: cancellationToken
                    );
                if (userOperationClaims == null)
                    throw new Exception("UserOperationClaims not found");

                #endregion

                var existingOperationClaimIds = userOperationClaims.Items.Select(uoc => uoc.OperationClaimId).ToList();

                var operationClaimsToAdd = authorGroupUserOperationClaims.Items
                    .Select(aguoc => aguoc.OperationClaimId)
                    .Except(existingOperationClaimIds)
                    .ToList();

                var operationClaimsToRemove = existingOperationClaimIds
                    .Except(authorGroupUserOperationClaims.Items.Select(aguoc => aguoc.OperationClaimId))
                    .ToList();

                foreach (var operationClaimId in operationClaimsToAdd)
                {
                    await _userOperationClaimService.AddAsync(new UserOperationClaim { UserId = user.Id, OperationClaimId = operationClaimId });
                }

                foreach (var operationClaimId in operationClaimsToRemove)
                {
                    var userOperationClaimToRemove = userOperationClaims.Items.FirstOrDefault(uoc => uoc.OperationClaimId == operationClaimId);
                    if (userOperationClaimToRemove != null)
                    {
                        await _userOperationClaimService.DeleteAsync(userOperationClaimToRemove, permanent: true);
                    }
                }
            }

            // Ger refreshed user with new OperationClaims and create access token

            User? refreshedUser = await _userService.GetAsync(
                predicate: u => u.Email == request.UserForLoginDto.Email,
                cancellationToken: cancellationToken
            );

            AccessToken createdAccessToken = await _authService.CreateAccessToken(refreshedUser);

            Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(refreshedUser, request.IpAddress);
            Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            await _authService.DeleteOldRefreshTokens(refreshedUser.Id);

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

            loggedResponse.AccessToken = createdAccessToken;
            loggedResponse.RefreshToken = addedRefreshToken;

            return loggedResponse;
        }
    }
}
