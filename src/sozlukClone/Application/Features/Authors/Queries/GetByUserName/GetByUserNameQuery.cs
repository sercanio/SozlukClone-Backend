using Application.Features.Authors.Rules;
using Application.Features.Users.Queries.GetById;
using Application.Services.Authors;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Application.Features.Authors.Queries.GetByUserName;

public class GetByUserNameQuery : IRequest<GetByUserNameResponse>
{
    public string UserName { get; set; }

    public class GetByUserNameQueryHandler : IRequestHandler<GetByUserNameQuery, GetByUserNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly AuthorBusinessRules _authorBusinessRules;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGlobalSettingRepository _globalSettingRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorService _authorService;

        public GetByUserNameQueryHandler(IMapper mapper, AuthorBusinessRules authorBusinessRules, IAuthorRepository authorRepository, IGlobalSettingRepository globalSettingRepository, IHttpContextAccessor httpContextAccessor, IAuthorService authorService = null)
        {
            _mapper = mapper;
            _authorBusinessRules = authorBusinessRules;
            _authorRepository = authorRepository;
            _globalSettingRepository = globalSettingRepository;
            _httpContextAccessor = httpContextAccessor;
            _authorService = authorService;
        }

        public async Task<GetByUserNameResponse> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
        {
            await _authorBusinessRules.AuthorNameShouldExistWhenSelected(request.UserName, cancellationToken);

            GlobalSetting? globalSettings = await _globalSettingRepository.GetAsync(predicate: gs => gs.Id == 1, cancellationToken: cancellationToken);

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

            IQueryable<GetByUserNameResponse> authorQuery = _authorRepository.Query()
                .Where(a => a.UserName == request.UserName)
                .Include(a => a.User)
                .Select(a => new
                {
                    Author = a,
                    ReceivedLikesCount = a.Entries.SelectMany(e => e.Likes).Count(),
                    ReceivedDislikesCount = a.Entries.SelectMany(e => e.Dislikes).Count(),
                    ReceivedFavoriteCount = a.Entries.SelectMany(e => e.Favorites).Count(),
                    ComplaintedEntriesCount = a.Entries.Count(e => e.Complaints.Any()),
                    ComplaintedTitlesCount = a.Titles.Count(t => t.Complaints.Any()),
                })
                .Select(a => new GetByUserNameResponse
                {
                    Id = a.Author.Id,
                    UserName = a.Author.UserName,
                    Biography = a.Author.Biography,
                    ProfilePictureUrl = a.Author.ProfilePictureUrl,
                    CoverPictureUrl = a.Author.CoverPictureUrl,
                    Age = a.Author.Age,
                    Gender = a.Author.Gender,
                    AuthorGroupId = a.Author.AuthorGroupId,
                    ActiveBadgeId = a.Author.ActiveBadgeId,
                    EntryCount = a.Author.Entries.Count(),
                    TitleCount = a.Author.Titles.Count(),
                    FollowingCount = a.Author.Followings.Count(),
                    FollowerCount = a.Author.Followers.Count(),
                    BlockingsCount = a.Author.Blockings.Count(),
                    BlockersCount = a.Author.Blockers.Count(),
                    GivenLikesCount = a.Author.Likes.Count(),
                    GivenDislikesCount = a.Author.Dislikes.Count(),
                    GivenFavoritesCount = a.Author.Favorites.Count(),
                    ReceivedLikesCount = a.ReceivedLikesCount,
                    ReceivedDislikesCount = a.ReceivedDislikesCount,
                    ReceivedFavoritesCount = a.ReceivedFavoriteCount,
                    FollowedTitlesMultiplier = a.Author.FollowedTitles.Count(),
                    BlockedTitlesCount = a.Author.BlockedTitles.Count(),
                    ComplaintCount = a.Author.Complaints.Count(),
                    ComplaintPendingCount = a.Author.Complaints.Count(c => c.Status == ComplaintStatusEnum.Pending),
                    ComplaintApprovedCount = a.Author.Complaints.Count(c => c.Status == ComplaintStatusEnum.Approved),
                    ComplaintRejectedCount = a.Author.Complaints.Count(c => c.Status == ComplaintStatusEnum.Rejected),
                    ComplaintedEntriesCount = a.ComplaintedEntriesCount,
                    ComplaintedTitlesCount = a.ComplaintedTitlesCount,
                    User = new GetByIdUserInAuthorResponse
                    {
                        Id = a.Author.User.Id,
                        Email = a.Author.User.Email
                    },
                    Karma = (int)(
                        globalSettings!.BaseKarma +
                        a.Author.Entries.Count() * globalSettings.EntryMultiplier +
                        a.Author.Titles.Count() * globalSettings.TitleMultiplier +
                        a.Author.Followings.Count() * globalSettings.FollowingMultiplier +
                        a.Author.Followers.Count() * globalSettings.FollowerMultiplier +
                        a.Author.Blockings.Count() * globalSettings.BlockingsMultiplier +
                        a.Author.Blockers.Count() * globalSettings.BlockersMultiplier +
                        a.Author.Likes.Count() * globalSettings.GivenLikesMultiplier +
                        a.Author.Dislikes.Count() * globalSettings.GivenDislikesMultiplier +
                        a.Author.Favorites.Count() * globalSettings.GivenFavoritesMultiplier +
                        a.ReceivedLikesCount * globalSettings.ReceivedLikesMultiplier +
                        a.ReceivedDislikesCount * globalSettings.ReceivedDislikesMultiplier +
                        a.ReceivedFavoriteCount * globalSettings.ReceivedFavoritesMultiplier +
                        a.Author.FollowedTitles.Count() * globalSettings.FollowedTitlesMultiplier +
                        a.Author.BlockedTitles.Count() * globalSettings.BlockedTitlesMultiplier +
                        a.Author.Complaints.Count() * globalSettings.ComplaintCountMultiplier +
                        a.Author.Complaints.Count(c => c.Status == ComplaintStatusEnum.Pending) * globalSettings.ComplaintPendingCountMultiplier +
                        a.Author.Complaints.Count(c => c.Status == ComplaintStatusEnum.Approved) * globalSettings.ComplaintApprovedCountMultiplier +
                        a.Author.Complaints.Count(c => c.Status == ComplaintStatusEnum.Rejected) * globalSettings.ComplaintRejectedCountMultiplier +
                        a.ComplaintedEntriesCount * globalSettings.ComplaintedEntriesMultiplier +
                        a.ComplaintedTitlesCount * globalSettings.ComplaintedTitlesMultiplier
                    ),
                    IsFollowing = author != null && a.Author.Followers.Any(af => af.FollowerId == author!.Id),
                    IsFollower = author != null && a.Author.Followings.Any(af => af.FollowerId == author!.Id),
                    IsBlocking = author != null && a.Author.Blockers.Any(ab => ab.BlockerId == author!.Id),
                    IsBlocker = author != null && a.Author.Blockings.Any(ab => ab.BlockerId == author!.Id),
                    AuthorFollowingId = author != null && a.Author.Followers.Any(af => af.FollowerId == author.Id) ? a.Author.Followers.FirstOrDefault(af => af.FollowerId == author!.Id)!.Id : null,
                    AuthorBlockingId = author != null && a.Author.Blockers.Any(af => af.BlockerId == author.Id) ? a.Author.Blockers.FirstOrDefault(af => af.BlockerId == author!.Id)!.Id : null,
                });

            GetByUserNameResponse? response = await authorQuery.FirstOrDefaultAsync(cancellationToken);

            return response!;
        }
    }
}
