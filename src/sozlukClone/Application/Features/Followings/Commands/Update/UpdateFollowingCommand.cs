using Application.Features.Followings.Constants;
using Application.Features.Followings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Followings.Constants.FollowingsOperationClaims;

namespace Application.Features.Followings.Commands.Update;

public class UpdateFollowingCommand : IRequest<UpdatedFollowingResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required uint FollowerId { get; set; }
    public required uint FollowedId { get; set; }

    public string[] Roles => [Admin, Write, FollowingsOperationClaims.Update];

    public class UpdateFollowingCommandHandler : IRequestHandler<UpdateFollowingCommand, UpdatedFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFollowingRepository _followingRepository;
        private readonly FollowingBusinessRules _followingBusinessRules;

        public UpdateFollowingCommandHandler(IMapper mapper, IFollowingRepository followingRepository,
                                         FollowingBusinessRules followingBusinessRules)
        {
            _mapper = mapper;
            _followingRepository = followingRepository;
            _followingBusinessRules = followingBusinessRules;
        }

        public async Task<UpdatedFollowingResponse> Handle(UpdateFollowingCommand request, CancellationToken cancellationToken)
        {
            Following? following = await _followingRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _followingBusinessRules.FollowingShouldExistWhenSelected(following);
            following = _mapper.Map(request, following);

            await _followingRepository.UpdateAsync(following!);

            UpdatedFollowingResponse response = _mapper.Map<UpdatedFollowingResponse>(following);
            return response;
        }
    }
}