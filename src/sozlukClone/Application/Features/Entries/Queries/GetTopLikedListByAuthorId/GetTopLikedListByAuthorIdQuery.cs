using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Queries.GetTopLikedListByAuthorId
{
    public class GetTopLikedListByAuthorIdQuery : IRequest<GetListResponse<GetTopLikedListByAuthorIdResponse>>
    {
        public int AuthorId { get; set; }
        public PageRequest PageRequest { get; set; }
    }

    public class GetTopLikedListByAuthorIdQueryHandler : IRequestHandler<GetTopLikedListByAuthorIdQuery, GetListResponse<GetTopLikedListByAuthorIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public GetTopLikedListByAuthorIdQueryHandler(IMapper mapper, EntryBusinessRules entryBusinessRules, IEntryRepository entryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
            _entryRepository = entryRepository;
        }

        public async Task<GetListResponse<GetTopLikedListByAuthorIdResponse>> Handle(GetTopLikedListByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Entry> entries = await _entryRepository.GetListAsync(
                predicate: e => e.AuthorId == request.AuthorId,
                include: e => e.Include(e => e.Title)
                               .Include(e => e.Author)
                               .Include(e => e.Likes)
                               .ThenInclude(l => l.Author),
                orderBy: e => e.OrderByDescending(e => e.Likes.Count),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            var mappedEntries = entries.Items.Select(e => _mapper.Map<GetTopLikedListByAuthorIdResponse>(e)).ToList();

            GetListResponse<GetTopLikedListByAuthorIdResponse> response = new GetListResponse<GetTopLikedListByAuthorIdResponse>
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
