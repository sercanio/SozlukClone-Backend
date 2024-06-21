using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Queries.GetTopLikedListByAuthorId;

public class GetTopLikedListByAuthorIdQuery : IRequest<GetListResponse<GetTopLikedListByAuthorIdResponse>>
{
    public int AuthorId { get; set; }
    public PageRequest PageRequest { get; set; }

    public class GetTopLikedListByAuthorIdQueryHandler : IRequestHandler<GetTopLikedListByAuthorIdQuery, GetListResponse<GetTopLikedListByAuthorIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public GetTopLikedListByAuthorIdQueryHandler(IMapper mapper, EntryBusinessRules entryBusinessRules, IEntryRepository entryRepository)
        {
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
            _entryRepository = entryRepository;
        }

        public async Task<GetListResponse<GetTopLikedListByAuthorIdResponse>> Handle(GetTopLikedListByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Entry> entries = await _entryRepository.GetListAsync(
                predicate: e => e.AuthorId == request.AuthorId,
                include: e => e.Include(e => e.Author)
                               .Include(e => e.Title)
                               .Include(e => e.Likes).ThenInclude(l => l.Author)
                               .Include(e => e.Dislikes).ThenInclude(l => l.Author)
                               .Include(e => e.Favorites).ThenInclude(l => l.Author),
                orderBy: e => e.OrderByDescending(e => e.Likes.Count),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetTopLikedListByAuthorIdResponse> response = _mapper.Map<GetListResponse<GetTopLikedListByAuthorIdResponse>>(entries);

            return response;
        }
    }
}
