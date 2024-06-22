using Application.Features.TitleBlockings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.TitleBlockings.Constants.TitleBlockingsOperationClaims;

namespace Application.Features.TitleBlockings.Queries.GetList;

public class GetListTitleBlockingQuery : IRequest<GetListResponse<GetListTitleBlockingListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListTitleBlockingQueryHandler : IRequestHandler<GetListTitleBlockingQuery, GetListResponse<GetListTitleBlockingListItemDto>>
    {
        private readonly ITitleBlockingRepository _titleBlockingRepository;
        private readonly IMapper _mapper;

        public GetListTitleBlockingQueryHandler(ITitleBlockingRepository titleBlockingRepository, IMapper mapper)
        {
            _titleBlockingRepository = titleBlockingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTitleBlockingListItemDto>> Handle(GetListTitleBlockingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TitleBlocking> titleBlockings = await _titleBlockingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTitleBlockingListItemDto> response = _mapper.Map<GetListResponse<GetListTitleBlockingListItemDto>>(titleBlockings);
            return response;
        }
    }
}