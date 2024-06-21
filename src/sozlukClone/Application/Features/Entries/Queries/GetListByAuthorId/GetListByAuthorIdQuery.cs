using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Queries.GetListByAuthorId;

public class GetListByAuthorIdQuery : IRequest<GetListResponse<GetListByAuthorIdResponse>>
{
    public int AuthorId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetListByAuthorIdQueryHandler : IRequestHandler<GetListByAuthorIdQuery, GetListResponse<GetListByAuthorIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public GetListByAuthorIdQueryHandler(IMapper mapper, EntryBusinessRules entryBusinessRules, IEntryRepository entryRepository)
        {
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
            _entryRepository = entryRepository;
        }

        public async Task<GetListResponse<GetListByAuthorIdResponse>> Handle(GetListByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Entry> entries = await _entryRepository.GetListAsync(
              predicate: e => e.AuthorId == request.AuthorId,
              include: e => e.Include(e => e.Author)
                             .Include(e => e.Title)
                             .Include(e => e.Likes).ThenInclude(l => l.Author)
                             .Include(e => e.Dislikes).ThenInclude(l => l.Author)
                             .Include(e => e.Favorites).ThenInclude(l => l.Author),
              orderBy: e => e.OrderByDescending(e => e.CreatedDate),
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken
            );

            GetListResponse<GetListByAuthorIdResponse> response = _mapper.Map<GetListResponse<GetListByAuthorIdResponse>>(entries);

            return response;
        }
    }
}
