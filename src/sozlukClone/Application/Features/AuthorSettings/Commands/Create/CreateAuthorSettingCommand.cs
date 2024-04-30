using Application.Features.AuthorSettings.Constants;
using Application.Features.AuthorSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.AuthorSettings.Constants.AuthorSettingsOperationClaims;

namespace Application.Features.AuthorSettings.Commands.Create;

public class CreateAuthorSettingCommand : IRequest<CreatedAuthorSettingResponse>, ISecuredRequest, ILoggableRequest
{
    public required string ProfilePictureUrl { get; set; }
    public required string CoverPictureUrl { get; set; }
    public required uint AuthorGroupId { get; set; }
    public required uint ActiveBadgeId { get; set; }

    public string[] Roles => [Admin, Write, AuthorSettingsOperationClaims.Create];

    public class CreateAuthorSettingCommandHandler : IRequestHandler<CreateAuthorSettingCommand, CreatedAuthorSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorSettingRepository _authorSettingRepository;
        private readonly AuthorSettingBusinessRules _authorSettingBusinessRules;

        public CreateAuthorSettingCommandHandler(IMapper mapper, IAuthorSettingRepository authorSettingRepository,
                                         AuthorSettingBusinessRules authorSettingBusinessRules)
        {
            _mapper = mapper;
            _authorSettingRepository = authorSettingRepository;
            _authorSettingBusinessRules = authorSettingBusinessRules;
        }

        public async Task<CreatedAuthorSettingResponse> Handle(CreateAuthorSettingCommand request, CancellationToken cancellationToken)
        {
            AuthorSetting authorSetting = _mapper.Map<AuthorSetting>(request);

            await _authorSettingRepository.AddAsync(authorSetting);

            CreatedAuthorSettingResponse response = _mapper.Map<CreatedAuthorSettingResponse>(authorSetting);
            return response;
        }
    }
}