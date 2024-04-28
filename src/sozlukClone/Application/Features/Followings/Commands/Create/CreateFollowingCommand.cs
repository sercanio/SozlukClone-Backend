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

namespace Application.Features.Followings.Commands.Create;

public class CreateFollowingCommand : IRequest<CreatedFollowingResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required uint FollowerId { get; set; }
    public required uint FollowedId { get; set; }

    public string[] Roles => [Admin, Write, FollowingsOperationClaims.Create];

    public class CreateFollowingCommandHandler : IRequestHandler<CreateFollowingCommand, CreatedFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFollowingRepository _followingRepository;
        private readonly FollowingBusinessRules _followingBusinessRules;

        public CreateFollowingCommandHandler(IMapper mapper, IFollowingRepository followingRepository,
                                         FollowingBusinessRules followingBusinessRules)
        {
            _mapper = mapper;
            _followingRepository = followingRepository;
            _followingBusinessRules = followingBusinessRules;
        }

        public async Task<CreatedFollowingResponse> Handle(CreateFollowingCommand request, CancellationToken cancellationToken)
        {
            Following? followingInDb = await _followingRepository.GetAsync(predicate: f => f.FollowerId == request.FollowerId && f.FollowedId == request.FollowedId, withDeleted: true, cancellationToken: cancellationToken);

            if (followingInDb != null)
            {
                if (followingInDb.DeletedDate != null)
                {
                    followingInDb.DeletedDate = null;
                    await _followingRepository.UpdateAsync(followingInDb);
                }
            }
            else
            {
                Following following = _mapper.Map<Following>(request);
                await _followingRepository.AddAsync(following);
                followingInDb = following;
            }

            CreatedFollowingResponse response = _mapper.Map<CreatedFollowingResponse>(followingInDb);
            return response;
        }
    }
}