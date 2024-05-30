using Application.Features.Users.Constants;
using Application.Features.Users.Rules;
using Application.Services.Authors;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdUserQuery : IRequest<GetByIdUserResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [UsersOperationClaims.Read];

    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IAuthorService _authorService;

        public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, IAuthorService authorService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
            _authorService = authorService;
        }

        public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(
                predicate: b => b.Id.Equals(request.Id),
                enableTracking: false,
                cancellationToken: cancellationToken
            );
            await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

            Author? author = await _authorService.GetAuthorByUserIdAsync(user.Id, cancellationToken);

            GetByIdUserResponse response = _mapper.Map<GetByIdUserResponse>(user);
            response.Author = author;
            return response;
        }
    }
}
