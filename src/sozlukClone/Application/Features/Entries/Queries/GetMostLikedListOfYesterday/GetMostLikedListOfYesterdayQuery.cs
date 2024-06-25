using Application.Features.Entries.Rules;
using Application.Services.Authors;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Application.Features.Entries.Queries.GetMostLikedListOfYesterday
{
    public class GetMostLikedListOfYesterdayQuery : IRequest<GetListResponse<GetMostLikedListOfYesterdayResponse>>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetMostLikedListOfYesterdayQueryHandler : IRequestHandler<GetMostLikedListOfYesterdayQuery, GetListResponse<GetMostLikedListOfYesterdayResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorService _authorService;

        public GetMostLikedListOfYesterdayQueryHandler(IMapper mapper, EntryBusinessRules entryBusinessRules, IEntryRepository entryRepository, IHttpContextAccessor httpContextAccessor, IAuthorService authorService)
        {
            _mapper = mapper;
            _entryBusinessRules = entryBusinessRules;
            _entryRepository = entryRepository;
            _httpContextAccessor = httpContextAccessor;
            _authorService = authorService;
        }

        public async Task<GetListResponse<GetMostLikedListOfYesterdayResponse>> Handle(GetMostLikedListOfYesterdayQuery request, CancellationToken cancellationToken)
        {
            Guid? userId = null;

            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out Guid parsedUserId))
            {
                userId = parsedUserId;
            }

            var yesterday = DateTime.Now.Subtract(TimeSpan.FromDays(1));
            var yesterdayStart = yesterday.Date.ToUniversalTime();
            var yesterdayEnd = yesterdayStart.AddDays(1).Subtract(TimeSpan.FromSeconds(1));

            Author? author = null;
            if (userId.HasValue)
            {
                author = await _authorService.GetAsync(a => a.UserId == userId.Value, cancellationToken: cancellationToken);
            }

            Expression<Func<Entry, bool>> predicate;

            if (userId.HasValue)
            {
                predicate = e => e.CreatedDate >= yesterdayStart && e.CreatedDate <= yesterdayEnd && e.Likes.Count > 0 && !(e.Author.Blockers.Any(u => u.BlockerId == author!.Id));
            }
            else
            {
                predicate = e => e.CreatedDate >= yesterdayStart && e.CreatedDate <= yesterdayEnd && e.Likes.Count > 0;
            }

            IPaginate<Entry> entries = await _entryRepository.GetListAsync(
                predicate: predicate,
                include: e => e.Include(e => e.Title)
                              .Include(e => e.Author)
                              .Include(e => e.Likes)
                              .ThenInclude(l => l.Author)
                              .Include(e => e.Dislikes)
                              .ThenInclude(l => l.Author)
                              .Include(e => e.Favorites)
                              .ThenInclude(l => l.Author),
                orderBy: e => e.OrderByDescending(e => e.Likes.Count),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            var mappedEntries = entries.Items.Select(e => _mapper.Map<GetMostLikedListOfYesterdayResponse>(e)).ToList();

            GetListResponse<GetMostLikedListOfYesterdayResponse> response = new GetListResponse<GetMostLikedListOfYesterdayResponse>
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
