using Application.Features.AuthorSettings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AuthorSettings.Constants.AuthorSettingsOperationClaims;

namespace Application.Features.AuthorSettings.Queries.GetList;

public class GetListAuthorSettingQuery : IRequest<GetListResponse<GetListAuthorSettingListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAuthorSettingQueryHandler : IRequestHandler<GetListAuthorSettingQuery, GetListResponse<GetListAuthorSettingListItemDto>>
    {
        private readonly IAuthorSettingRepository _authorSettingRepository;
        private readonly IMapper _mapper;

        public GetListAuthorSettingQueryHandler(IAuthorSettingRepository authorSettingRepository, IMapper mapper)
        {
            _authorSettingRepository = authorSettingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorSettingListItemDto>> Handle(GetListAuthorSettingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorSetting> authorSettings = await _authorSettingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorSettingListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorSettingListItemDto>>(authorSettings);
            return response;
        }
    }
}