using Application.Features.AuthorGroupUserOperationClaims.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AuthorGroupUserOperationClaims.Constants.AuthorGroupUserOperationClaimsOperationClaims;

namespace Application.Features.AuthorGroupUserOperationClaims.Queries.GetList;

public class GetListAuthorGroupUserOperationClaimQuery : IRequest<GetListResponse<GetListAuthorGroupUserOperationClaimListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAuthorGroupUserOperationClaimQueryHandler : IRequestHandler<GetListAuthorGroupUserOperationClaimQuery, GetListResponse<GetListAuthorGroupUserOperationClaimListItemDto>>
    {
        private readonly IAuthorGroupUserOperationClaimRepository _authorGroupUserOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListAuthorGroupUserOperationClaimQueryHandler(IAuthorGroupUserOperationClaimRepository authorGroupUserOperationClaimRepository, IMapper mapper)
        {
            _authorGroupUserOperationClaimRepository = authorGroupUserOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorGroupUserOperationClaimListItemDto>> Handle(GetListAuthorGroupUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorGroupUserOperationClaim> authorGroupUserOperationClaims = await _authorGroupUserOperationClaimRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorGroupUserOperationClaimListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorGroupUserOperationClaimListItemDto>>(authorGroupUserOperationClaims);
            return response;
        }
    }
}