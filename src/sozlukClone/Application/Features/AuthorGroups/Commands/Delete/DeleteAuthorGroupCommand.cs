using Application.Features.AuthorGroups.Constants;
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

namespace Application.Features.AuthorGroups.Commands.Delete;

public class DeleteAuthorGroupCommand : IRequest<DeletedAuthorGroupResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Write, AuthorGroupsOperationClaims.Delete];

    public class DeleteAuthorGroupCommandHandler : IRequestHandler<DeleteAuthorGroupCommand, DeletedAuthorGroupResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupRepository _authorGroupRepository;
        private readonly AuthorGroupBusinessRules _authorGroupBusinessRules;

        public DeleteAuthorGroupCommandHandler(IMapper mapper, IAuthorGroupRepository authorGroupRepository,
                                         AuthorGroupBusinessRules authorGroupBusinessRules)
        {
            _mapper = mapper;
            _authorGroupRepository = authorGroupRepository;
            _authorGroupBusinessRules = authorGroupBusinessRules;
        }

        public async Task<DeletedAuthorGroupResponse> Handle(DeleteAuthorGroupCommand request, CancellationToken cancellationToken)
        {
            AuthorGroup? authorGroup = await _authorGroupRepository.GetAsync(predicate: ag => ag.Id == request.Id, cancellationToken: cancellationToken);
            await _authorGroupBusinessRules.AuthorGroupShouldExistWhenSelected(authorGroup);

            await _authorGroupRepository.DeleteAsync(authorGroup!);

            DeletedAuthorGroupResponse response = _mapper.Map<DeletedAuthorGroupResponse>(authorGroup);
            return response;
        }
    }
}