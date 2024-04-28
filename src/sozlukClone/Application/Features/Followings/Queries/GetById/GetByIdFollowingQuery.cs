using Application.Features.Followings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.Followings.Constants.FollowingsOperationClaims;

namespace Application.Features.Followings.Queries.GetById;

public class GetByIdFollowingQuery : IRequest<GetByIdFollowingResponse>, ISecuredRequest
{
    public uint FollowerId { get; set; }
    public uint FollowedId { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdFollowingQueryHandler : IRequestHandler<GetByIdFollowingQuery, GetByIdFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFollowingRepository _followingRepository;
        private readonly FollowingBusinessRules _followingBusinessRules;

        public GetByIdFollowingQueryHandler(IMapper mapper, IFollowingRepository followingRepository, FollowingBusinessRules followingBusinessRules)
        {
            _mapper = mapper;
            _followingRepository = followingRepository;
            _followingBusinessRules = followingBusinessRules;
        }

        public async Task<GetByIdFollowingResponse> Handle(GetByIdFollowingQuery request, CancellationToken cancellationToken)
        {
            Following? following = await _followingRepository.GetAsync(predicate: f => f.FollowerId == request.FollowerId && f.FollowedId == request.FollowedId, cancellationToken: cancellationToken);
            await _followingBusinessRules.FollowingShouldExistWhenSelected(following);

            GetByIdFollowingResponse response = _mapper.Map<GetByIdFollowingResponse>(following);
            return response;
        }
    }
}