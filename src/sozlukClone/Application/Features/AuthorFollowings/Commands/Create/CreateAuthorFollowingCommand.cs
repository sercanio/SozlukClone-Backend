using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.AuthorFollowings.Commands.Create;

public class CreateAuthorFollowingCommand : IRequest<CreatedAuthorFollowingResponse>, ILoggableRequest
{
    public required int FollowingId { get; set; }
    public required int FollowerId { get; set; }

    public class CreateAuthorFollowingCommandHandler : IRequestHandler<CreateAuthorFollowingCommand, CreatedAuthorFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorFollowingRepository _authorFollowingRepository;
        private readonly AuthorFollowingBusinessRules _authorFollowingBusinessRules;

        public CreateAuthorFollowingCommandHandler(IMapper mapper, IAuthorFollowingRepository authorFollowingRepository,
                                         AuthorFollowingBusinessRules authorFollowingBusinessRules)
        {
            _mapper = mapper;
            _authorFollowingRepository = authorFollowingRepository;
            _authorFollowingBusinessRules = authorFollowingBusinessRules;
        }

        public async Task<CreatedAuthorFollowingResponse> Handle(CreateAuthorFollowingCommand request, CancellationToken cancellationToken)
        {
            AuthorFollowing following = _mapper.Map<AuthorFollowing>(request);

            await _authorFollowingBusinessRules.FollowingShouldNotOwnedByEntryAuthorWhenSelected(following, cancellationToken);
            await _authorFollowingBusinessRules.FollowingShouldNotDuplicatedWhenInserted(following, cancellationToken);
            await _authorFollowingBusinessRules.BlockingShouldNotExistsWhenFollowingInserted(following, cancellationToken);

            await _authorFollowingRepository.AddAsync(following);

            CreatedAuthorFollowingResponse response = _mapper.Map<CreatedAuthorFollowingResponse>(following);
            return response;
        }
    }
}