using Application.Features.Titles.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Titles.Constants.TitlesOperationClaims;

namespace Application.Features.Titles.Queries.GetList;

public class GetListTitleQuery : IRequest<GetListResponse<GetListTitleListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListTitleQueryHandler : IRequestHandler<GetListTitleQuery, GetListResponse<GetListTitleListItemDto>>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        public GetListTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTitleListItemDto>> Handle(GetListTitleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Title> titles = await _titleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTitleListItemDto> response = _mapper.Map<GetListResponse<GetListTitleListItemDto>>(titles);
            return response;
        }
    }
}