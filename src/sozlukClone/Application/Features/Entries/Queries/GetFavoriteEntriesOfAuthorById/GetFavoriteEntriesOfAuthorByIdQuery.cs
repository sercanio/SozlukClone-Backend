using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Queries.GetFavoriteEntriesOfAuthorById
{
    public class GetFavoriteEntriesOfAuthorByIdQuery : IRequest<GetListResponse<GetFavoriteEntriesOfAuthorByIdResponse>>
    {
        public int AuthorId { get; set; }
        public PageRequest PageRequest { get; set; }
    }

    public class GetFavoriteEntriesOfAuthorByIdQueryHandler : IRequestHandler<GetFavoriteEntriesOfAuthorByIdQuery, GetListResponse<GetFavoriteEntriesOfAuthorByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public GetFavoriteEntriesOfAuthorByIdQueryHandler(IMapper mapper, EntryBusinessRules entryBusinessRules, IEntryRepository entryRepository)
        {
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
            _entryRepository = entryRepository;
        }

        public async Task<GetListResponse<GetFavoriteEntriesOfAuthorByIdResponse>> Handle(GetFavoriteEntriesOfAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Entry> entries = await _entryRepository.GetListAsync(
                predicate: e => e.Favorites.Any(f => f.AuthorId == request.AuthorId),
                include: e => e.Include(e => e.Author)
                               .Include(e => e.Title)
                               .Include(e => e.Likes).ThenInclude(l => l.Author)
                               .Include(e => e.Dislikes).ThenInclude(l => l.Author)
                               .Include(e => e.Favorites).ThenInclude(f => f.Author),
                orderBy: e => e.OrderByDescending(e => e.CreatedDate),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            var mappedEntries = entries.Items.Select(e => _mapper.Map<GetFavoriteEntriesOfAuthorByIdResponse>(e)).ToList();

            GetListResponse<GetFavoriteEntriesOfAuthorByIdResponse> response = new GetListResponse<GetFavoriteEntriesOfAuthorByIdResponse>
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