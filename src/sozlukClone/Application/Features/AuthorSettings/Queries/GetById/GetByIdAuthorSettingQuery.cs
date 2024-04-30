using Application.Features.AuthorSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.AuthorSettings.Constants.AuthorSettingsOperationClaims;

namespace Application.Features.AuthorSettings.Queries.GetById;

public class GetByIdAuthorSettingQuery : IRequest<GetByIdAuthorSettingResponse>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAuthorSettingQueryHandler : IRequestHandler<GetByIdAuthorSettingQuery, GetByIdAuthorSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorSettingRepository _authorSettingRepository;
        private readonly AuthorSettingBusinessRules _authorSettingBusinessRules;

        public GetByIdAuthorSettingQueryHandler(IMapper mapper, IAuthorSettingRepository authorSettingRepository, AuthorSettingBusinessRules authorSettingBusinessRules)
        {
            _mapper = mapper;
            _authorSettingRepository = authorSettingRepository;
            _authorSettingBusinessRules = authorSettingBusinessRules;
        }

        public async Task<GetByIdAuthorSettingResponse> Handle(GetByIdAuthorSettingQuery request, CancellationToken cancellationToken)
        {
            AuthorSetting? authorSetting = await _authorSettingRepository.GetAsync(predicate: ast => ast.Id == request.Id, cancellationToken: cancellationToken);
            await _authorSettingBusinessRules.AuthorSettingShouldExistWhenSelected(authorSetting);

            GetByIdAuthorSettingResponse response = _mapper.Map<GetByIdAuthorSettingResponse>(authorSetting);
            return response;
        }
    }
}