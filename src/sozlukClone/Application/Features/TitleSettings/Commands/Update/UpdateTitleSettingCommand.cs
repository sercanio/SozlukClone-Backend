using Application.Features.TitleSettings.Constants;
using Application.Features.TitleSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.TitleSettings.Constants.TitleSettingsOperationClaims;

namespace Application.Features.TitleSettings.Commands.Update;

public class UpdateTitleSettingCommand : IRequest<UpdatedTitleSettingResponse>, ISecuredRequest, ILoggableRequest
{
    public uint Id { get; set; }
    public required byte MinTitleLength { get; set; }
    public required byte MaxTitleLength { get; set; }
    public required bool TitleCanHaveLink { get; set; }
    public required bool TitleCanHaveSpecialCharacter { get; set; }
    public required bool TitleCanHavePunctuation { get; set; }

    public string[] Roles => [Admin, Write, TitleSettingsOperationClaims.Update];

    public class UpdateTitleSettingCommandHandler : IRequestHandler<UpdateTitleSettingCommand, UpdatedTitleSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleSettingRepository _titleSettingRepository;
        private readonly TitleSettingBusinessRules _titleSettingBusinessRules;

        public UpdateTitleSettingCommandHandler(IMapper mapper, ITitleSettingRepository titleSettingRepository,
                                         TitleSettingBusinessRules titleSettingBusinessRules)
        {
            _mapper = mapper;
            _titleSettingRepository = titleSettingRepository;
            _titleSettingBusinessRules = titleSettingBusinessRules;
        }

        public async Task<UpdatedTitleSettingResponse> Handle(UpdateTitleSettingCommand request, CancellationToken cancellationToken)
        {
            TitleSetting? titleSetting = await _titleSettingRepository.GetAsync(predicate: ts => ts.Id == request.Id, cancellationToken: cancellationToken);
            await _titleSettingBusinessRules.TitleSettingShouldExistWhenSelected(titleSetting);
            titleSetting = _mapper.Map(request, titleSetting);

            await _titleSettingRepository.UpdateAsync(titleSetting!);

            UpdatedTitleSettingResponse response = _mapper.Map<UpdatedTitleSettingResponse>(titleSetting);
            return response;
        }
    }
}