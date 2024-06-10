using Application.Features.GlobalSettings.Constants;
using Application.Features.GlobalSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.GlobalSettings.Constants.GlobalSettingsOperationClaims;

namespace Application.Features.GlobalSettings.Commands.Create;

public class CreateGlobalSettingCommand : IRequest<CreatedGlobalSettingResponse>, ISecuredRequest, ILoggableRequest
{
    public string? SiteName { get; set; }
    public string? SiteDescription { get; set; }
    public string? SiteFavIcon { get; set; }
    public string? SiteLogo { get; set; }
    public string? SiteLogoFooter { get; set; }
    public string? SiteLogoMobile { get; set; }
    public int? MaxTitleLength { get; set; }
    public int? DefaultAuthorGroupId { get; set; }
    public bool? IsAuthorRegistrationAllowed { get; set; }
    public int? MaxEntryLength { get; set; }

    public string[] Roles => [Admin, Write, GlobalSettingsOperationClaims.Create];

    public class CreateGlobalSettingCommandHandler : IRequestHandler<CreateGlobalSettingCommand, CreatedGlobalSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGlobalSettingRepository _globalSettingRepository;
        private readonly GlobalSettingBusinessRules _globalSettingBusinessRules;

        public CreateGlobalSettingCommandHandler(IMapper mapper, IGlobalSettingRepository globalSettingRepository,
                                         GlobalSettingBusinessRules globalSettingBusinessRules)
        {
            _mapper = mapper;
            _globalSettingRepository = globalSettingRepository;
            _globalSettingBusinessRules = globalSettingBusinessRules;
        }

        public async Task<CreatedGlobalSettingResponse> Handle(CreateGlobalSettingCommand request, CancellationToken cancellationToken)
        {
            GlobalSetting globalSetting = _mapper.Map<GlobalSetting>(request);

            await _globalSettingBusinessRules.GlobalSettingShouldBeUnique();

            await _globalSettingRepository.AddAsync(globalSetting);

            CreatedGlobalSettingResponse response = _mapper.Map<CreatedGlobalSettingResponse>(globalSetting);
            return response;
        }
    }
}