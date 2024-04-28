using Application.Features.Followings.Constants;
using Application.Features.Followings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Followings.Constants.FollowingsOperationClaims;

namespace Application.Features.Followings.Commands.Delete;

public class DeleteFollowingCommand : IRequest<DeletedFollowingResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }

    public string[] Roles => [Admin, Write, FollowingsOperationClaims.Delete];

    public class DeleteFollowingCommandHandler : IRequestHandler<DeleteFollowingCommand, DeletedFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFollowingRepository _followingRepository;
        private readonly FollowingBusinessRules _followingBusinessRules;

        public DeleteFollowingCommandHandler(IMapper mapper, IFollowingRepository followingRepository,
                                         FollowingBusinessRules followingBusinessRules)
        {
            _mapper = mapper;
            _followingRepository = followingRepository;
            _followingBusinessRules = followingBusinessRules;
        }

        public async Task<DeletedFollowingResponse> Handle(DeleteFollowingCommand request, CancellationToken cancellationToken)
        {
            Following? following = await _followingRepository.GetAsync(predicate: f => f.FollowerId == request.FollowerId && f.FollowedId == request.FollowedId, cancellationToken: cancellationToken);
            await _followingBusinessRules.FollowingShouldExistWhenSelected(following);

            await _followingRepository.DeleteAsync(following!);

            DeletedFollowingResponse response = _mapper.Map<DeletedFollowingResponse>(following);
            return response;
        }
    }
}