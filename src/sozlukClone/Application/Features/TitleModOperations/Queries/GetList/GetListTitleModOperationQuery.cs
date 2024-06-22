using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.TitleModOperations.Constants.TitleModOperationsOperationClaims;

namespace Application.Features.TitleModOperations.Queries.GetList;

public class GetListTitleModOperationQuery : IRequest<GetListResponse<GetListTitleModOperationListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListTitleModOperationQueryHandler : IRequestHandler<GetListTitleModOperationQuery, GetListResponse<GetListTitleModOperationListItemDto>>
    {
        private readonly ITitleModOperationRepository _titleModOperationRepository;
        private readonly IMapper _mapper;

        public GetListTitleModOperationQueryHandler(ITitleModOperationRepository titleModOperationRepository, IMapper mapper)
        {
            _titleModOperationRepository = titleModOperationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTitleModOperationListItemDto>> Handle(GetListTitleModOperationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TitleModOperation> titleModOperations = await _titleModOperationRepository.GetListAsync(
                include: tmo => tmo.Include(tmo => tmo.Issuer)
                                   .Include(tmo => tmo.Title),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTitleModOperationListItemDto> response = _mapper.Map<GetListResponse<GetListTitleModOperationListItemDto>>(titleModOperations);
            return response;
        }
    }
}