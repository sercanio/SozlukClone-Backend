using Application.Features.GlobalSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.GlobalSettings.Constants.GlobalSettingsOperationClaims;

namespace Application.Features.GlobalSettings.Commands.Delete;

public class DeleteGlobalSettingCommand : IRequest<DeletedGlobalSettingResponse>, ISecuredRequest, ILoggableRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin];

    public class DeleteGlobalSettingCommandHandler : IRequestHandler<DeleteGlobalSettingCommand, DeletedGlobalSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGlobalSettingRepository _globalSettingRepository;
        private readonly GlobalSettingBusinessRules _globalSettingBusinessRules;

        public DeleteGlobalSettingCommandHandler(IMapper mapper, IGlobalSettingRepository globalSettingRepository,
                                         GlobalSettingBusinessRules globalSettingBusinessRules)
        {
            _mapper = mapper;
            _globalSettingRepository = globalSettingRepository;
            _globalSettingBusinessRules = globalSettingBusinessRules;
        }

        public async Task<DeletedGlobalSettingResponse> Handle(DeleteGlobalSettingCommand request, CancellationToken cancellationToken)
        {
            GlobalSetting? globalSetting = await _globalSettingRepository.GetAsync(predicate: gs => gs.Id == request.Id, cancellationToken: cancellationToken);
            await _globalSettingBusinessRules.GlobalSettingShouldExistWhenSelected(globalSetting);

            await _globalSettingRepository.DeleteAsync(globalSetting!, true);

            DeletedGlobalSettingResponse response = _mapper.Map<DeletedGlobalSettingResponse>(globalSetting);
            return response;
        }
    }
}