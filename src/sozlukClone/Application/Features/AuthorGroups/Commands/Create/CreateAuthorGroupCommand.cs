using Application.Features.AuthorGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.AuthorGroups.Constants.AuthorGroupsOperationClaims;

namespace Application.Features.AuthorGroups.Commands.Create;

public class CreateAuthorGroupCommand : IRequest<CreatedAuthorGroupResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => [Admin];

    public class CreateAuthorGroupCommandHandler : IRequestHandler<CreateAuthorGroupCommand, CreatedAuthorGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupRepository _authorGroupRepository;
        private readonly AuthorGroupBusinessRules _authorGroupBusinessRules;

        public CreateAuthorGroupCommandHandler(IMapper mapper, IAuthorGroupRepository authorGroupRepository,
                                         AuthorGroupBusinessRules authorGroupBusinessRules)
        {
            _mapper = mapper;
            _authorGroupRepository = authorGroupRepository;
            _authorGroupBusinessRules = authorGroupBusinessRules;
        }

        public async Task<CreatedAuthorGroupResponse> Handle(CreateAuthorGroupCommand request, CancellationToken cancellationToken)
        {
            AuthorGroup authorGroup = _mapper.Map<AuthorGroup>(request);

            await _authorGroupRepository.AddAsync(authorGroup);

            CreatedAuthorGroupResponse response = _mapper.Map<CreatedAuthorGroupResponse>(authorGroup);
            return response;
        }
    }
}