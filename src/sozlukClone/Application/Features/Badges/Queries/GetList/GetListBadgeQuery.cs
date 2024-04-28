using Application.Features.Badges.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Badges.Constants.BadgesOperationClaims;

namespace Application.Features.Badges.Queries.GetList;

public class GetListBadgeQuery : IRequest<GetListResponse<GetListBadgeListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListBadgeQueryHandler : IRequestHandler<GetListBadgeQuery, GetListResponse<GetListBadgeListItemDto>>
    {
        private readonly IBadgeRepository _badgeRepository;
        private readonly IMapper _mapper;

        public GetListBadgeQueryHandler(IBadgeRepository badgeRepository, IMapper mapper)
        {
            _badgeRepository = badgeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBadgeListItemDto>> Handle(GetListBadgeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Badge> badges = await _badgeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBadgeListItemDto> response = _mapper.Map<GetListResponse<GetListBadgeListItemDto>>(badges);
            return response;
        }
    }
}