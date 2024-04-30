using Application.Features.Authors.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
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
    public string? Biography { get; set; } = null;
    public string? ProfilePictureUrl { get; set; } = null;
    public string? CoverPictureUrl { get; set; } = null;
    public byte? Age { get; set; }
    public Gender? Gender { get; set; }

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

            await _authorBusinessRules.AuthorUserNameShouldOnlyHaveLettersAndNumbers(request.UserName);
            await _authorBusinessRules.AuthorUserNameShouldHaveMinumumLength(request.UserName, 3);
            // If you change the minimum length, you should change the validation message in the localization file.
            await _authorBusinessRules.AuthorUserNameShouldHaveMaximumLength(request.UserName, 40);
            // If you change the maximum length, you should change the validation message in the localization file.
            await _authorBusinessRules.AuthorUserNameShouldBeUnique(request.UserName);

            User user = await _userService.Register(new UserForRegisterDto() { Email = request.Email, Password = request.Password });

            Author author = _mapper.Map<Author>(request);
            author.UserId = user.Id;
            author.AuthorGroupId = 1; // Default author group id
            author.ActiveBadgeId = 1; // Default active badge id

            var savedAuthor = await _authorRepository.AddAsync(author);

            CreatedAuthorResponse response = _mapper.Map<CreatedAuthorResponse>(savedAuthor);
            return response;
        }
    }
}