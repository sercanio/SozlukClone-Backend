using Application.Features.Authors.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;

namespace Application.Features.Authors.Commands.Create;

public class CreateAuthorCommand : IRequest<CreatedAuthorResponse>, ILoggableRequest, ITransactionalRequest
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Biography { get; set; }
    public required string ProfilePictureUrl { get; set; }
    public required string CoverPictureUrl { get; set; }
    public required byte AuthorGroupId { get; set; }
    public required byte ActiveBadgeId { get; set; }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreatedAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;
        private readonly IUserService _userService;

        public CreateAuthorCommandHandler(IMapper mapper, IAuthorRepository authorRepository,
                                         AuthorBusinessRules authorBusinessRules, IUserService userService)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _authorBusinessRules = authorBusinessRules;
            _userService = userService;
        }

        public async Task<CreatedAuthorResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            //Author author = _mapper.Map<Author>(request);

            //await _authorRepository.AddAsync(author);

            //CreatedAuthorResponse response = _mapper.Map<CreatedAuthorResponse>(author);
            //return response;

            //await _authorBusinessRules.MemberNumberCanNotBeDuplicatedWhenInserted(request.PhoneNumber);
            User user = await _userService.Register(new UserForRegisterDto() { Email = request.Email, Password = request.Password });
            //string[] Roles = UserDefaultRoles.Roles;

            //for (int i = 0; i < Roles.Length; i++)
            //{
            //    OperationClaim? operationClaim = await _operationClaimService.GetAsync(oc => oc.Name == Roles[i]);
            //    await _userOperationClaimService.AddAsync(new UserOperationClaim() { UserId = user.Id, OperationClaimId = operationClaim!.Id });
            //}

            Author author = _mapper.Map<Author>(request);
            author.UserId = user.Id;

            var savedAuthor = await _authorRepository.AddAsync(author);

            //MemberSetting memberSetting = await _memberSettingService.AddAsync(new MemberSetting() { MemberId = savedMember.Id });
            //member.MemberSetting.Id = memberSetting.Id;


            //_mailService.SendMail(new NArchitecture.Core.Mailing.Mail
            //{
            //    Subject = "Test Mail",
            //    HtmlBody = "Welcome to the Tobeto Public Library",
            //    ToList = [new MailboxAddress($"{member.FirstName} {member.LastName}", $"{member.Email}")]
            //});


            CreatedAuthorResponse response = _mapper.Map<CreatedAuthorResponse>(author);
            return response;
        }
    }
}