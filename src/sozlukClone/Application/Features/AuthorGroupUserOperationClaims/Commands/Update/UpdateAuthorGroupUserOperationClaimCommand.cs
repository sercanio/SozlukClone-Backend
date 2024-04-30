using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Features.AuthorGroupUserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.AuthorGroupUserOperationClaims.Constants.AuthorGroupUserOperationClaimsOperationClaims;

namespace Application.Features.AuthorGroupUserOperationClaims.Commands.Update;

public class UpdateAuthorGroupUserOperationClaimCommand : IRequest<UpdatedAuthorGroupUserOperationClaimResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int OperationClaimId { get; set; }
    public required int AuthorGroupId { get; set; }

    public string[] Roles => [Admin, Write, AuthorGroupUserOperationClaimsOperationClaims.Update];

    public class UpdateAuthorGroupUserOperationClaimCommandHandler : IRequestHandler<UpdateAuthorGroupUserOperationClaimCommand, UpdatedAuthorGroupUserOperationClaimResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorGroupUserOperationClaimRepository _authorGroupUserOperationClaimRepository;
        private readonly AuthorGroupUserOperationClaimBusinessRules _authorGroupUserOperationClaimBusinessRules;

        public UpdateAuthorGroupUserOperationClaimCommandHandler(IMapper mapper, IAuthorGroupUserOperationClaimRepository authorGroupUserOperationClaimRepository,
                                         AuthorGroupUserOperationClaimBusinessRules authorGroupUserOperationClaimBusinessRules)
        {
            _mapper = mapper;
            _authorGroupUserOperationClaimRepository = authorGroupUserOperationClaimRepository;
            _authorGroupUserOperationClaimBusinessRules = authorGroupUserOperationClaimBusinessRules;
        }

        public async Task<UpdatedAuthorGroupUserOperationClaimResponse> Handle(UpdateAuthorGroupUserOperationClaimCommand request, CancellationToken cancellationToken)
        {
            AuthorGroupUserOperationClaim? authorGroupUserOperationClaim = await _authorGroupUserOperationClaimRepository.GetAsync(predicate: aguoc => aguoc.Id == request.Id, cancellationToken: cancellationToken);
            await _authorGroupUserOperationClaimBusinessRules.AuthorGroupUserOperationClaimShouldExistWhenSelected(authorGroupUserOperationClaim);
            authorGroupUserOperationClaim = _mapper.Map(request, authorGroupUserOperationClaim);

            await _authorGroupUserOperationClaimRepository.UpdateAsync(authorGroupUserOperationClaim!);

            UpdatedAuthorGroupUserOperationClaimResponse response = _mapper.Map<UpdatedAuthorGroupUserOperationClaimResponse>(authorGroupUserOperationClaim);
            return response;
        }
    }
}