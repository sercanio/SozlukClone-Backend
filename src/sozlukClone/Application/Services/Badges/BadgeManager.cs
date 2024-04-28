using Application.Features.Badges.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Badges;

public class BadgeManager : IBadgeService
{
    private readonly IBadgeRepository _badgeRepository;
    private readonly BadgeBusinessRules _badgeBusinessRules;

    public BadgeManager(IBadgeRepository badgeRepository, BadgeBusinessRules badgeBusinessRules)
    {
        _badgeRepository = badgeRepository;
        _badgeBusinessRules = badgeBusinessRules;
    }

    public async Task<Badge?> GetAsync(
        Expression<Func<Badge, bool>> predicate,
        Func<IQueryable<Badge>, IIncludableQueryable<Badge, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Badge? badge = await _badgeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return badge;
    }

    public async Task<IPaginate<Badge>?> GetListAsync(
        Expression<Func<Badge, bool>>? predicate = null,
        Func<IQueryable<Badge>, IOrderedQueryable<Badge>>? orderBy = null,
        Func<IQueryable<Badge>, IIncludableQueryable<Badge, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Badge> badgeList = await _badgeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return badgeList;
    }

    public async Task<Badge> AddAsync(Badge badge)
    {
        Badge addedBadge = await _badgeRepository.AddAsync(badge);

        return addedBadge;
    }

    public async Task<Badge> UpdateAsync(Badge badge)
    {
        Badge updatedBadge = await _badgeRepository.UpdateAsync(badge);

        return updatedBadge;
    }

    public async Task<Badge> DeleteAsync(Badge badge, bool permanent = false)
    {
        Badge deletedBadge = await _badgeRepository.DeleteAsync(badge);

        return deletedBadge;
    }
}
