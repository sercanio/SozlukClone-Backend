using Application.Features.EntryModOperations.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.EntryModOperations.Constants.EntryModOperationsOperationClaims;

namespace Application.Features.EntryModOperations.Queries.GetList;

public class GetListEntryModOperationQuery : IRequest<GetListResponse<GetListEntryModOperationListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListEntryModOperationQueryHandler : IRequestHandler<GetListEntryModOperationQuery, GetListResponse<GetListEntryModOperationListItemDto>>
    {
        private readonly IEntryModOperationRepository _entryModOperationRepository;
        private readonly IMapper _mapper;

        public GetListEntryModOperationQueryHandler(IEntryModOperationRepository entryModOperationRepository, IMapper mapper)
        {
            _entryModOperationRepository = entryModOperationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEntryModOperationListItemDto>> Handle(GetListEntryModOperationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EntryModOperation> entryModOperations = await _entryModOperationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEntryModOperationListItemDto> response = _mapper.Map<GetListResponse<GetListEntryModOperationListItemDto>>(entryModOperations);
            return response;
        }
    }
}