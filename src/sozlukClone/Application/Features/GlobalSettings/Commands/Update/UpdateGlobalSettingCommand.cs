using Application.Features.GlobalSettings.Constants;
using Application.Features.GlobalSettings.Rules;
using Application.Services.ImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.GlobalSettings.Constants.GlobalSettingsOperationClaims;

namespace Application.Features.GlobalSettings.Commands.Update
{
    public class UpdateGlobalSettingCommand : IRequest<UpdatedGlobalSettingResponse>, ISecuredRequest, ILoggableRequest
    {
        public int Id { get; set; }
        public string? SiteName { get; set; }
        public string? SiteDescription { get; set; }
        public IFormFile? SiteFavIcon { get; set; }
        public IFormFile? SiteLogo { get; set; }
        public IFormFile? SiteLogoFooter { get; set; }
        public IFormFile? SiteLogoMobile { get; set; }
        public int? MaxTitleLength { get; set; }
        public int? DefaultAuthorGroupId { get; set; }
        public bool? IsAuthorRegistrationAllowed { get; set; }
        public int? MaxEntryLength { get; set; }

        public string[] Roles => new string[] { Admin, Write, GlobalSettingsOperationClaims.Update };

        public class UpdateGlobalSettingCommandHandler : IRequestHandler<UpdateGlobalSettingCommand, UpdatedGlobalSettingResponse>
        {
            private readonly IMapper _mapper;
            private readonly IGlobalSettingRepository _globalSettingRepository;
            private readonly GlobalSettingBusinessRules _globalSettingBusinessRules;
            private readonly ImageServiceBase _imageService;

            public UpdateGlobalSettingCommandHandler(IMapper mapper, IGlobalSettingRepository globalSettingRepository,
                                                     GlobalSettingBusinessRules globalSettingBusinessRules,
                                                     ImageServiceBase imageService)
            {
                _mapper = mapper;
                _globalSettingRepository = globalSettingRepository;
                _globalSettingBusinessRules = globalSettingBusinessRules;
                _imageService = imageService;
            }

            public async Task<UpdatedGlobalSettingResponse> Handle(UpdateGlobalSettingCommand request, CancellationToken cancellationToken)
            {

                GlobalSetting globalSetting = _mapper.Map<GlobalSetting>(request);
                await _globalSettingBusinessRules.GlobalSettingShouldExistWhenSelected(globalSetting);


                if (request.SiteFavIcon != null && globalSetting != null)
                {
                    globalSetting.SiteFavIcon = await UploadImageToCloud(request.SiteFavIcon);
                }

                if (request.SiteLogo != null && globalSetting != null)
                {
                    globalSetting.SiteLogo = await UploadImageToCloud(request.SiteLogo);
                }

                await _globalSettingRepository.UpdateAsync(globalSetting!);

                UpdatedGlobalSettingResponse response = _mapper.Map<UpdatedGlobalSettingResponse>(globalSetting);
                return response;
            }

            private async Task<string> UploadImageToCloud(IFormFile formFile)
            {
                string imageUrl = await _imageService.UploadAsync(formFile);

                return imageUrl;
            }
        }
    }
}
