using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Features.AuthorGroupUserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AuthorGroupUserOperationClaims.Constants.AuthorGroupUserOperationClaimsOperationClaims;

namespace Application.Features.AuthorGroupUserOperationClaims.Queries.GetById;

public class GetByIdAuthorGroupUserOperationClaimQuery : IRequest<GetByIdAuthorGroupUserOperationClaimResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAuthorGroupUserOperationClaimQueryHandler : IRequestHandler<GetByIdAuthorGroupUserOperationClaimQuery, GetByIdAuthorGroupUserOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupUserOperationClaimRepository _authorGroupUserOperationClaimRepository;
        private readonly AuthorGroupUserOperationClaimBusinessRules _authorGroupUserOperationClaimBusinessRules;

        public GetByIdAuthorGroupUserOperationClaimQueryHandler(IMapper mapper, IAuthorGroupUserOperationClaimRepository authorGroupUserOperationClaimRepository, AuthorGroupUserOperationClaimBusinessRules authorGroupUserOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _authorGroupUserOperationClaimRepository = authorGroupUserOperationClaimRepository;
            _authorGroupUserOperationClaimBusinessRules = authorGroupUserOperationClaimBusinessRules;
        }

        public async Task<GetByIdAuthorGroupUserOperationClaimResponse> Handle(GetByIdAuthorGroupUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            AuthorGroupUserOperationClaim? authorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.GetAsync(predicate: aguoc => aguoc.Id == request.Id, cancellationToken: cancellationToken);
            await _authorGroupUserOperationClaimBusinessRules.AuthorGroupUserOperationClaimShouldExistWhenSelected(authorGroupUserOperationClaim);

            GetByIdAuthorGroupUserOperationClaimResponse response = _mapper.Map<GetByIdAuthorGroupUserOperationClaimResponse>(authorGroupUserOperationClaim);
            return response;
        }
    }
}