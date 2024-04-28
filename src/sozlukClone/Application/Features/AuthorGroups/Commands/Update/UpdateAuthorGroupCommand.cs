using Application.Features.AuthorGroups.Constants;
using Application.Features.AuthorGroups.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AuthorGroups.Constants.AuthorGroupsOperationClaims;

namespace Application.Features.AuthorGroups.Commands.Update;

public class UpdateAuthorGroupCommand : IRequest<UpdatedAuthorGroupResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public string[] Roles => [Admin, Write, AuthorGroupsOperationClaims.Update];

    public class UpdateAuthorGroupCommandHandler : IRequestHandler<UpdateAuthorGroupCommand, UpdatedAuthorGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupRepository _authorGroupRepository;
        private readonly AuthorGroupBusinessRules _authorGroupBusinessRules;

        public UpdateAuthorGroupCommandHandler(IMapper mapper, IAuthorGroupRepository authorGroupRepository,
                                         AuthorGroupBusinessRules authorGroupBusinessRules)
        {
            _mapper = mapper;
            _authorGroupRepository = authorGroupRepository;
            _authorGroupBusinessRules = authorGroupBusinessRules;
        }

        public async Task<UpdatedAuthorGroupResponse> Handle(UpdateAuthorGroupCommand request, CancellationToken cancellationToken)
        {
            AuthorGroup? authorGroup = await _authorGroupRepository.GetAsync(predicate: ag => ag.Id == request.Id, cancellationToken: cancellationToken);
            await _authorGroupBusinessRules.AuthorGroupShouldExistWhenSelected(authorGroup);
            authorGroup = _mapper.Map(request, authorGroup);

            await _authorGroupRepository.UpdateAsync(authorGroup!);

            UpdatedAuthorGroupResponse response = _mapper.Map<UpdatedAuthorGroupResponse>(authorGroup);
            return response;
        }
    }
}