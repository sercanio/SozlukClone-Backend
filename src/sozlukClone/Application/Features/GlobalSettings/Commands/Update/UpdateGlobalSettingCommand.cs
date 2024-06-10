using Application.Features.GlobalSettings.Constants;
using Application.Features.GlobalSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.GlobalSettings.Constants.GlobalSettingsOperationClaims;

namespace Application.Features.GlobalSettings.Commands.Update;

public class UpdateGlobalSettingCommand : IRequest<UpdatedGlobalSettingResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }
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

    public string[] Roles => [Admin, Write, GlobalSettingsOperationClaims.Update];

    public class UpdateGlobalSettingCommandHandler : IRequestHandler<UpdateGlobalSettingCommand, UpdatedGlobalSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGlobalSettingRepository _globalSettingRepository;
        private readonly GlobalSettingBusinessRules _globalSettingBusinessRules;

        public UpdateGlobalSettingCommandHandler(IMapper mapper, IGlobalSettingRepository globalSettingRepository,
                                         GlobalSettingBusinessRules globalSettingBusinessRules)
        {
            _mapper = mapper;
            _globalSettingRepository = globalSettingRepository;
            _globalSettingBusinessRules = globalSettingBusinessRules;
        }

        public async Task<UpdatedGlobalSettingResponse> Handle(UpdateGlobalSettingCommand request, CancellationToken cancellationToken)
        {
            GlobalSetting? globalSetting = await _globalSettingRepository.GetAsync(predicate: gs => gs.Id == request.Id, cancellationToken: cancellationToken);
            await _globalSettingBusinessRules.GlobalSettingShouldExistWhenSelected(globalSetting);
            globalSetting = _mapper.Map(request, globalSetting);

            await _globalSettingRepository.UpdateAsync(globalSetting!);

            UpdatedGlobalSettingResponse response = _mapper.Map<UpdatedGlobalSettingResponse>(globalSetting);
            return response;
        }
    }
}