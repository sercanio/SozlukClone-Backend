using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Queries.GetMostFavoritedListByAuthorId
{
    public class GetMostFavoritedListByAuthorIdQuery : IRequest<GetListResponse<GetMostFavoritedListByAuthorIdResponse>>
    {
        public int AuthorId { get; set; }
        public PageRequest PageRequest { get; set; }
    }

    public class GetMostFavoritedListByAuthorIdQueryHandler : IRequestHandler<GetMostFavoritedListByAuthorIdQuery, GetListResponse<GetMostFavoritedListByAuthorIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public GetMostFavoritedListByAuthorIdQueryHandler(IMapper mapper, EntryBusinessRules entryBusinessRules, IEntryRepository entryRepository)
        {
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
            _entryRepository = entryRepository;
        }

        public async Task<GetListResponse<GetMostFavoritedListByAuthorIdResponse>> Handle(GetMostFavoritedListByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Entry> entries = await _entryRepository.GetListAsync(
            predicate: e => e.AuthorId == request.AuthorId,
            include: e => e.Include(e => e.Author)
                           .Include(e => e.Title)
                           .Include(e => e.Likes).ThenInclude(l => l.Author)
                           .Include(e => e.Dislikes).ThenInclude(l => l.Author)
                           .Include(e => e.Favorites).ThenInclude(l => l.Author),
            orderBy: e => e.OrderByDescending(e => e.Favorites.Count),
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            cancellationToken: cancellationToken
            );

            var mappedEntries = entries.Items.Select(e => _mapper.Map<GetMostFavoritedListByAuthorIdResponse>(e)).ToList();

            GetListResponse<GetMostFavoritedListByAuthorIdResponse> response = new GetListResponse<GetMostFavoritedListByAuthorIdResponse>
            {
                Items = mappedEntries,
                Index = entries.Index,
                Size = entries.Size,
                Count = entries.Count,
                Pages = entries.Pages
            };

            return response;
        }
    }
}
