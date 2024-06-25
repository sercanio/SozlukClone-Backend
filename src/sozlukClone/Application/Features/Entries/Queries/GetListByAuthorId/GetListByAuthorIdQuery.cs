using Application.Features.Authors.Queries.GetById;
using Application.Features.Entries.Rules;
using Application.Features.Titles.Queries.GetById;
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
using System.Security.Claims;

namespace Application.Features.Entries.Queries.GetListByAuthorId
{
    public class GetListByAuthorIdQuery : IRequest<GetListResponse<GetListByAuthorIdListItemDto>>
    {
        public int AuthorId { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListByAuthorIdQueryHandler : IRequestHandler<GetListByAuthorIdQuery, GetListResponse<GetListByAuthorIdListItemDto>>
        {
            private readonly IMapper _mapper;
            private readonly IEntryRepository _entryRepository;
            private readonly EntryBusinessRules _entryBusinessRules;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IAuthorService _authorService;

            public GetListByAuthorIdQueryHandler(IMapper mapper, EntryBusinessRules entryBusinessRules, IEntryRepository entryRepository, IHttpContextAccessor httpContextAccessor, IAuthorService authorService)
            {
                _mapper = mapper;
                _entryBusinessRules = entryBusinessRules;
                _entryRepository = entryRepository;
                _httpContextAccessor = httpContextAccessor;
                _authorService = authorService;
            }

            public async Task<GetListResponse<GetListByAuthorIdListItemDto>> Handle(GetListByAuthorIdQuery request, CancellationToken cancellationToken)
            {
                Guid? userId = null;

                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userIdClaim) && Guid.TryParse(userIdClaim, out Guid parsedUserId))
                {
                    userId = parsedUserId;
                }
                Author? author = null;

                if (userId.HasValue)
                {
                    author = await _authorService.GetAsync(predicate: a => a.UserId == userId.Value, cancellationToken: cancellationToken);
                }

                IPaginate<Entry> entries = await _entryRepository.GetListAsync(
                  predicate: e => e.AuthorId == request.AuthorId,
                  include: e => e.Include(e => e.Title)
                                 .Include(e => e.Author)
                                 .Include(e => e.Likes)
                                 .Include(e => e.Dislikes)
                                 .Include(e => e.Favorites),
                  orderBy: e => e.OrderByDescending(e => e.CreatedDate),
                  index: request.PageRequest.PageIndex,
                  size: request.PageRequest.PageSize,
                  cancellationToken: cancellationToken
                );

                var mappedEntries = entries.Items.Select(e => new GetListByAuthorIdListItemDto
                {
                    Id = e.Id,
                    Content = e.Content,
                    CreatedDate = e.CreatedDate,
                    UpdatedDate = e.UpdatedDate,
                    LikesCount = e.Likes.Count,
                    DislikesCount = e.Dislikes.Count,
                    FavoritesCount = e.Favorites.Count,
                    Title = _mapper.Map<GetByIdTitleForEntryResponse>(e.Title),
                    Author = _mapper.Map<GetByIdAuthorForEntryResponse>(e.Author),
                    AuthorLike = author != null && e.Likes.Any(l => l.AuthorId == author.Id),
                    AuthorDislike = author != null && e.Dislikes.Any(d => d.AuthorId == author.Id),
                    AuthorFavorite = author != null && e.Favorites.Any(f => f.AuthorId == author.Id)
                }).ToList();

                GetListResponse<GetListByAuthorIdListItemDto> response = new GetListResponse<GetListByAuthorIdListItemDto>
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
}
