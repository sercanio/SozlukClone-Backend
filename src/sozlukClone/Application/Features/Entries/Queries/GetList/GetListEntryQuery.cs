using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Queries.GetList;

public class GetListEntryQuery : IRequest<GetListResponse<GetListEntryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

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
                include: e => e.Include(e => e.Author)
                                .Include(e => e.Likes).ThenInclude(l => l.Author)
                                .Include(e => e.Dislikes).ThenInclude(l => l.Author)
                                .Include(e => e.Favorites).ThenInclude(l => l.Author),
                orderBy: e => e.OrderByDescending(e => e.CreatedDate),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEntryListItemDto> response = _mapper.Map<GetListResponse<GetListEntryListItemDto>>(entries);
            return response;
        }
    }
}