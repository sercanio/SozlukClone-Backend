using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Features.AuthorGroupUserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.AuthorGroupUserOperationClaims.Constants.AuthorGroupUserOperationClaimsOperationClaims;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Delete;

public class DeleteAuthorGroupUserOperationClaimCommand : IRequest<DeletedAuthorGroupUserOperationClaimResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AuthorGroupUserOperationClaimsOperationClaims.Delete];

    public class DeleteAuthorGroupUserOperationClaimCommandHandler : IRequestHandler<DeleteAuthorGroupUserOperationClaimCommand, DeletedAuthorGroupUserOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupUserOperationClaimRepository _authorGroupUserOperationClaimRepository;
        private readonly AuthorGroupUserOperationClaimBusinessRules _authorGroupUserOperationClaimBusinessRules;

        public DeleteAuthorGroupUserOperationClaimCommandHandler(IMapper mapper, IAuthorGroupUserOperationClaimRepository authorGroupUserOperationClaimRepository,
                                         AuthorGroupUserOperationClaimBusinessRules authorGroupUserOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _authorGroupUserOperationClaimRepository = authorGroupUserOperationClaimRepository;
            _authorGroupUserOperationClaimBusinessRules = authorGroupUserOperationClaimBusinessRules;
        }

        public async Task<DeletedAuthorGroupUserOperationClaimResponse> Handle(DeleteAuthorGroupUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            AuthorGroupUserOperationClaim? authorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.GetAsync(predicate: aguoc => aguoc.Id == request.Id, cancellationToken: cancellationToken);
            await _authorGroupUserOperationClaimBusinessRules.AuthorGroupUserOperationClaimShouldExistWhenSelected(authorGroupUserOperationClaim);

            await _authorGroupUserOperationClaimRepository.DeleteAsync(authorGroupUserOperationClaim!);

            DeletedAuthorGroupUserOperationClaimResponse response = _mapper.Map<DeletedAuthorGroupUserOperationClaimResponse>(authorGroupUserOperationClaim);
            return response;
        }
    }
}