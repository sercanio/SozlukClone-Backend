using Application.Features.Followings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Followings.Constants.FollowingsOperationClaims;

namespace Application.Features.Followings.Queries.GetList;

public class GetListFollowingQuery : IRequest<GetListResponse<GetListFollowingListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListFollowingQueryHandler : IRequestHandler<GetListFollowingQuery, GetListResponse<GetListFollowingListItemDto>>
    {
        private readonly IFollowingRepository _followingRepository;
        private readonly IMapper _mapper;

        public GetListFollowingQueryHandler(IFollowingRepository followingRepository, IMapper mapper)
        {
            _followingRepository = followingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFollowingListItemDto>> Handle(GetListFollowingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Following> followings = await _followingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFollowingListItemDto> response = _mapper.Map<GetListResponse<GetListFollowingListItemDto>>(followings);
            return response;
        }
    }
}