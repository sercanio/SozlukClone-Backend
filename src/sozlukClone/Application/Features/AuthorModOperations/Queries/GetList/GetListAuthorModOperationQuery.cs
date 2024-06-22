using Application.Features.AuthorModOperations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AuthorModOperations.Constants.AuthorModOperationsOperationClaims;

namespace Application.Features.AuthorModOperations.Queries.GetList;

public class GetListAuthorModOperationQuery : IRequest<GetListResponse<GetListAuthorModOperationListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAuthorModOperationQueryHandler : IRequestHandler<GetListAuthorModOperationQuery, GetListResponse<GetListAuthorModOperationListItemDto>>
    {
        private readonly IAuthorModOperationRepository _authorModOperationRepository;
        private readonly IMapper _mapper;

        public GetListAuthorModOperationQueryHandler(IAuthorModOperationRepository authorModOperationRepository, IMapper mapper)
        {
            _authorModOperationRepository = authorModOperationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorModOperationListItemDto>> Handle(GetListAuthorModOperationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorModOperation> authorModOperations = await _authorModOperationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorModOperationListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorModOperationListItemDto>>(authorModOperations);
            return response;
        }
    }
}