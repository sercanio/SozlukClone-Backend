using Application.Features.AuthorSettings.Constants;
using Application.Features.AuthorSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.AuthorSettings.Constants.AuthorSettingsOperationClaims;

namespace Application.Features.AuthorSettings.Commands.Update;

public class UpdateAuthorSettingCommand : IRequest<UpdatedAuthorSettingResponse>, ISecuredRequest, ILoggableRequest
{
    public uint Id { get; set; }
    public required string ProfilePictureUrl { get; set; }
    public required string CoverPictureUrl { get; set; }
    public required uint ActiveBadgeId { get; set; }

    public string[] Roles => [Admin, Write, AuthorSettingsOperationClaims.Update];

    public class UpdateAuthorSettingCommandHandler : IRequestHandler<UpdateAuthorSettingCommand, UpdatedAuthorSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorSettingRepository _authorSettingRepository;
        private readonly AuthorSettingBusinessRules _authorSettingBusinessRules;

        public UpdateAuthorSettingCommandHandler(IMapper mapper, IAuthorSettingRepository authorSettingRepository,
                                         AuthorSettingBusinessRules authorSettingBusinessRules)
        {
            _mapper = mapper;
            _authorSettingRepository = authorSettingRepository;
            _authorSettingBusinessRules = authorSettingBusinessRules;
        }

        public async Task<UpdatedAuthorSettingResponse> Handle(UpdateAuthorSettingCommand request, CancellationToken cancellationToken)
        {
            AuthorSetting? authorSetting = await _authorSettingRepository.GetAsync(predicate: ast => ast.Id == request.Id, cancellationToken: cancellationToken);
            await _authorSettingBusinessRules.AuthorSettingShouldExistWhenSelected(authorSetting);
            authorSetting = _mapper.Map(request, authorSetting);

            await _authorSettingRepository.UpdateAsync(authorSetting!);

            UpdatedAuthorSettingResponse response = _mapper.Map<UpdatedAuthorSettingResponse>(authorSetting);
            return response;
        }
    }
}