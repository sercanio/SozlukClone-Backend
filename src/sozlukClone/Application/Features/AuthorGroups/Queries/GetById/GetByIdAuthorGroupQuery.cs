using Application.Features.AuthorGroups.Constants;
using Application.Features.AuthorGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AuthorGroups.Constants.AuthorGroupsOperationClaims;

namespace Application.Features.AuthorGroups.Queries.GetById;

public class GetByIdAuthorGroupQuery : IRequest<GetByIdAuthorGroupResponse>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAuthorGroupQueryHandler : IRequestHandler<GetByIdAuthorGroupQuery, GetByIdAuthorGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupRepository _authorGroupRepository;
        private readonly AuthorGroupBusinessRules _authorGroupBusinessRules;

        public GetByIdAuthorGroupQueryHandler(IMapper mapper, IAuthorGroupRepository authorGroupRepository, AuthorGroupBusinessRules authorGroupBusinessRules)
        {
            _mapper = mapper;
            _authorGroupRepository = authorGroupRepository;
            _authorGroupBusinessRules = authorGroupBusinessRules;
        }

        public async Task<GetByIdAuthorGroupResponse> Handle(GetByIdAuthorGroupQuery request, CancellationToken cancellationToken)
        {
            AuthorGroup? authorGroup = await _authorGroupRepository.GetAsync(predicate: ag => ag.Id == request.Id, cancellationToken: cancellationToken);
            await _authorGroupBusinessRules.AuthorGroupShouldExistWhenSelected(authorGroup);

            GetByIdAuthorGroupResponse response = _mapper.Map<GetByIdAuthorGroupResponse>(authorGroup);
            return response;
        }
    }
}