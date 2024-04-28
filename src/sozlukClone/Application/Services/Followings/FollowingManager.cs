using Application.Features.Followings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Followings;

public class FollowingManager : IFollowingService
{
    private readonly IFollowingRepository _followingRepository;
    private readonly FollowingBusinessRules _followingBusinessRules;

    public FollowingManager(IFollowingRepository followingRepository, FollowingBusinessRules followingBusinessRules)
    {
        _followingRepository = followingRepository;
        _followingBusinessRules = followingBusinessRules;
    }

    public async Task<Following?> GetAsync(
        Expression<Func<Following, bool>> predicate,
        Func<IQueryable<Following>, IIncludableQueryable<Following, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Following? following = await _followingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return following;
    }

    public async Task<IPaginate<Following>?> GetListAsync(
        Expression<Func<Following, bool>>? predicate = null,
        Func<IQueryable<Following>, IOrderedQueryable<Following>>? orderBy = null,
        Func<IQueryable<Following>, IIncludableQueryable<Following, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Following> followingList = await _followingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return followingList;
    }

    public async Task<Following> AddAsync(Following following)
    {
        Following addedFollowing = await _followingRepository.AddAsync(following);

        return addedFollowing;
    }

    public async Task<Following> UpdateAsync(Following following)
    {
        Following updatedFollowing = await _followingRepository.UpdateAsync(following);

        return updatedFollowing;
    }

    public async Task<Following> DeleteAsync(Following following, bool permanent = false)
    {
        Following deletedFollowing = await _followingRepository.DeleteAsync(following);

        return deletedFollowing;
    }
}
