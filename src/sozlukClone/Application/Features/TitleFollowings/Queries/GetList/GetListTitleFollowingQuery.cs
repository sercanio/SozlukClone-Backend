using Application.Features.TitleFollowings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.TitleFollowings.Constants.TitleFollowingsOperationClaims;

namespace Application.Features.TitleFollowings.Queries.GetList;

public class GetListTitleFollowingQuery : IRequest<GetListResponse<GetListTitleFollowingListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListTitleFollowingQueryHandler : IRequestHandler<GetListTitleFollowingQuery, GetListResponse<GetListTitleFollowingListItemDto>>
    {
        private readonly ITitleFollowingRepository _titleFollowingRepository;
        private readonly IMapper _mapper;

        public GetListTitleFollowingQueryHandler(ITitleFollowingRepository titleFollowingRepository, IMapper mapper)
        {
            _titleFollowingRepository = titleFollowingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTitleFollowingListItemDto>> Handle(GetListTitleFollowingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TitleFollowing> titleFollowings = await _titleFollowingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTitleFollowingListItemDto> response = _mapper.Map<GetListResponse<GetListTitleFollowingListItemDto>>(titleFollowings);
            return response;
        }
    }
}