using Application.Features.GlobalSettings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.GlobalSettings.Constants.GlobalSettingsOperationClaims;

namespace Application.Features.GlobalSettings.Queries.GetList;

public class GetListGlobalSettingQuery : IRequest<GetListResponse<GetListGlobalSettingListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListGlobalSettingQueryHandler : IRequestHandler<GetListGlobalSettingQuery, GetListResponse<GetListGlobalSettingListItemDto>>
    {
        private readonly IGlobalSettingRepository _globalSettingRepository;
        private readonly IMapper _mapper;

        public GetListGlobalSettingQueryHandler(IGlobalSettingRepository globalSettingRepository, IMapper mapper)
        {
            _globalSettingRepository = globalSettingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGlobalSettingListItemDto>> Handle(GetListGlobalSettingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GlobalSetting> globalSettings = await _globalSettingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGlobalSettingListItemDto> response = _mapper.Map<GetListResponse<GetListGlobalSettingListItemDto>>(globalSettings);
            return response;
        }
    }
}