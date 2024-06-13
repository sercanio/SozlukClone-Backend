using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Entries.Constants.EntriesOperationClaims;

namespace Application.Features.Entries.Queries.GetList;

public class GetListEntryQuery : IRequest<GetListResponse<GetListEntryListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListEntryQueryHandler : IRequestHandler<GetListEntryQuery, GetListResponse<GetListEntryListItemDto>>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public GetListEntryQueryHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEntryListItemDto>> Handle(GetListEntryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Entry> entries = await _entryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEntryListItemDto> response = _mapper.Map<GetListResponse<GetListEntryListItemDto>>(entries);
            return response;
        }
    }
}