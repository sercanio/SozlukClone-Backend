using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Features.AuthorGroupUserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.AuthorGroupUserOperationClaims.Constants.AuthorGroupUserOperationClaimsOperationClaims;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Create;

public class CreateAuthorGroupUserOperationClaimCommand : IRequest<CreatedAuthorGroupUserOperationClaimResponse>, ISecuredRequest, ILoggableRequest
{
    public required int OperationClaimId { get; set; }
    public required int AuthorGroupId { get; set; }

    public string[] Roles => [Admin, Write, AuthorGroupUserOperationClaimsOperationClaims.Create];

    public class CreateAuthorGroupUserOperationClaimCommandHandler : IRequestHandler<CreateAuthorGroupUserOperationClaimCommand, CreatedAuthorGroupUserOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupUserOperationClaimRepository _authorGroupUserOperationClaimRepository;
        private readonly AuthorGroupUserOperationClaimBusinessRules _authorGroupUserOperationClaimBusinessRules;

        public CreateAuthorGroupUserOperationClaimCommandHandler(IMapper mapper, IAuthorGroupUserOperationClaimRepository authorGroupUserOperationClaimRepository,
                                         AuthorGroupUserOperationClaimBusinessRules authorGroupUserOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _authorGroupUserOperationClaimRepository = authorGroupUserOperationClaimRepository;
            _authorGroupUserOperationClaimBusinessRules = authorGroupUserOperationClaimBusinessRules;
        }

        public async Task<CreatedAuthorGroupUserOperationClaimResponse> Handle(CreateAuthorGroupUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            AuthorGroupUserOperationClaim authorGroupUserOperationClaim = _mapper.Map<AuthorGroupUserOperationClaim>(request);

            await _authorGroupUserOperationClaimRepository.AddAsync(authorGroupUserOperationClaim);

            CreatedAuthorGroupUserOperationClaimResponse response = _mapper.Map<CreatedAuthorGroupUserOperationClaimResponse>(authorGroupUserOperationClaim);
            return response;
        }
    }
}