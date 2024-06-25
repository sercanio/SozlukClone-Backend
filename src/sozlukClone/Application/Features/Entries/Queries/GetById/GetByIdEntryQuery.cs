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
using System.Security.Claims;

namespace Application.Features.Entries.Queries.GetById
{
    public class GetByIdEntryQuery : IRequest<GetByIdEntryResponse>
    {
        public int Id { get; set; }

        public class GetByIdEntryQueryHandler : IRequestHandler<GetByIdEntryQuery, GetByIdEntryResponse>
        {
            private readonly IMapper _mapper;
            private readonly IEntryRepository _entryRepository;
            private readonly EntryBusinessRules _entryBusinessRules;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IAuthorService _authorService;

            public GetByIdEntryQueryHandler(IMapper mapper, IEntryRepository entryRepository, EntryBusinessRules entryBusinessRules, IHttpContextAccessor httpContextAccessor, IAuthorService authorService)
            {
                _mapper = mapper;
                _entryRepository = entryRepository;
                _entryBusinessRules = entryBusinessRules;
                _httpContextAccessor = httpContextAccessor;
                _authorService = authorService;
            }

            public async Task<GetByIdEntryResponse> Handle(GetByIdEntryQuery request, CancellationToken cancellationToken)
            {

                await _entryBusinessRules.EntryIdShouldExistWhenSelected(request.Id, cancellationToken);

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

                IQueryable<GetByIdEntryResponse> entryQuery = _entryRepository.Query()
                    .Where(e => e.Id == request.Id)
                    .Include(e => e.Title)
                    .Include(e => e.Author)
                    .Select(e => new GetByIdEntryResponse
                    {
                        Id = e.Id,
                        Content = e.Content,
                        CreatedDate = e.CreatedDate,
                        UpdatedDate = e.UpdatedDate,
                        LikesCount = e.Likes.Count,
                        Title = _mapper.Map<GetByIdTitleForEntryResponse>(e.Title),
                        Author = _mapper.Map<GetByIdAuthorForEntryResponse>(e.Author),
                        DislikesCount = e.Dislikes.Count,
                        FavoritesCount = e.Favorites.Count,
                        AuthorLike = author != null && e.Likes.Any(l => l.AuthorId == author.Id),
                        AuthorDislike = author != null && e.Dislikes.Any(d => d.AuthorId == author.Id),
                        AuthorFavorite = author != null && e.Favorites.Any(f => f.AuthorId == author.Id)
                    });

                GetByIdEntryResponse? response = await entryQuery.FirstOrDefaultAsync(cancellationToken);

                return response!;
            }
        }
    }
}
