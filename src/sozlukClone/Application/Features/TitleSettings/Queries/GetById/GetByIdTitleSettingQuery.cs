using Application.Features.TitleSettings.Constants;
using Application.Features.TitleSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TitleSettings.Constants.TitleSettingsOperationClaims;

namespace Application.Features.TitleSettings.Queries.GetById;

public class GetByIdTitleSettingQuery : IRequest<GetByIdTitleSettingResponse>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTitleSettingQueryHandler : IRequestHandler<GetByIdTitleSettingQuery, GetByIdTitleSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleSettingRepository _titleSettingRepository;
        private readonly TitleSettingBusinessRules _titleSettingBusinessRules;

        public GetByIdTitleSettingQueryHandler(IMapper mapper, ITitleSettingRepository titleSettingRepository, TitleSettingBusinessRules titleSettingBusinessRules)
        {
            _mapper = mapper;
            _titleSettingRepository = titleSettingRepository;
            _titleSettingBusinessRules = titleSettingBusinessRules;
        }

        public async Task<GetByIdTitleSettingResponse> Handle(GetByIdTitleSettingQuery request, CancellationToken cancellationToken)
        {
            TitleSetting? titleSetting = await _titleSettingRepository.GetAsync(predicate: ts => ts.Id == request.Id, cancellationToken: cancellationToken);
            await _titleSettingBusinessRules.TitleSettingShouldExistWhenSelected(titleSetting);

            GetByIdTitleSettingResponse response = _mapper.Map<GetByIdTitleSettingResponse>(titleSetting);
            return response;
        }
    }
}