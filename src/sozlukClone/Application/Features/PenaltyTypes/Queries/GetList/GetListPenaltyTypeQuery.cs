using Application.Features.PenaltyTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.PenaltyTypes.Constants.PenaltyTypesOperationClaims;

namespace Application.Features.PenaltyTypes.Queries.GetList;

public class GetListPenaltyTypeQuery : IRequest<GetListResponse<GetListPenaltyTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListPenaltyTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetPenaltyTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListPenaltyTypeQueryHandler : IRequestHandler<GetListPenaltyTypeQuery, GetListResponse<GetListPenaltyTypeListItemDto>>
    {
        private readonly IPenaltyTypeRepository _penaltyTypeRepository;
        private readonly IMapper _mapper;

        public GetListPenaltyTypeQueryHandler(IPenaltyTypeRepository penaltyTypeRepository, IMapper mapper)
        {
            _penaltyTypeRepository = penaltyTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPenaltyTypeListItemDto>> Handle(GetListPenaltyTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PenaltyType> penaltyTypes = await _penaltyTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPenaltyTypeListItemDto> response = _mapper.Map<GetListResponse<GetListPenaltyTypeListItemDto>>(penaltyTypes);
            return response;
        }
    }
}