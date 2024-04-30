using Application.Features.AuthorSettings.Constants;
using Application.Features.AuthorSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.AuthorSettings.Constants.AuthorSettingsOperationClaims;

namespace Application.Features.AuthorSettings.Commands.Delete;

public class DeleteAuthorSettingCommand : IRequest<DeletedAuthorSettingResponse>, ISecuredRequest, ILoggableRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Write, AuthorSettingsOperationClaims.Delete];

    public class DeleteAuthorSettingCommandHandler : IRequestHandler<DeleteAuthorSettingCommand, DeletedAuthorSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorSettingRepository _authorSettingRepository;
        private readonly AuthorSettingBusinessRules _authorSettingBusinessRules;

        public DeleteAuthorSettingCommandHandler(IMapper mapper, IAuthorSettingRepository authorSettingRepository,
                                         AuthorSettingBusinessRules authorSettingBusinessRules)
        {
            _mapper = mapper;
            _authorSettingRepository = authorSettingRepository;
            _authorSettingBusinessRules = authorSettingBusinessRules;
        }

        public async Task<DeletedAuthorSettingResponse> Handle(DeleteAuthorSettingCommand request, CancellationToken cancellationToken)
        {
            AuthorSetting? authorSetting = await _authorSettingRepository.GetAsync(predicate: ast => ast.Id == request.Id, cancellationToken: cancellationToken);
            await _authorSettingBusinessRules.AuthorSettingShouldExistWhenSelected(authorSetting);

            await _authorSettingRepository.DeleteAsync(authorSetting!);

            DeletedAuthorSettingResponse response = _mapper.Map<DeletedAuthorSettingResponse>(authorSetting);
            return response;
        }
    }
}