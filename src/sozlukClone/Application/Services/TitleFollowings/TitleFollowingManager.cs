using Application.Features.TitleFollowings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleFollowings;

public class TitleFollowingManager : ITitleFollowingService
{
    private readonly ITitleFollowingRepository _titleFollowingRepository;
    private readonly TitleFollowingBusinessRules _titleFollowingBusinessRules;

    public TitleFollowingManager(ITitleFollowingRepository titleFollowingRepository, TitleFollowingBusinessRules titleFollowingBusinessRules)
    {
        _titleFollowingRepository = titleFollowingRepository;
        _titleFollowingBusinessRules = titleFollowingBusinessRules;
    }

    public async Task<TitleFollowing?> GetAsync(
        Expression<Func<TitleFollowing, bool>> predicate,
        Func<IQueryable<TitleFollowing>, IIncludableQueryable<TitleFollowing, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TitleFollowing? titleFollowing = await _titleFollowingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return titleFollowing;
    }

    public async Task<IPaginate<TitleFollowing>?> GetListAsync(
        Expression<Func<TitleFollowing, bool>>? predicate = null,
        Func<IQueryable<TitleFollowing>, IOrderedQueryable<TitleFollowing>>? orderBy = null,
        Func<IQueryable<TitleFollowing>, IIncludableQueryable<TitleFollowing, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TitleFollowing> titleFollowingList = await _titleFollowingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return titleFollowingList;
    }

    public async Task<TitleFollowing> AddAsync(TitleFollowing titleFollowing)
    {
        TitleFollowing addedTitleFollowing = await _titleFollowingRepository.AddAsync(titleFollowing);

        return addedTitleFollowing;
    }

    public async Task<TitleFollowing> UpdateAsync(TitleFollowing titleFollowing)
    {
        TitleFollowing updatedTitleFollowing = await _titleFollowingRepository.UpdateAsync(titleFollowing);

        return updatedTitleFollowing;
    }

    public async Task<TitleFollowing> DeleteAsync(TitleFollowing titleFollowing, bool permanent = false)
    {
        TitleFollowing deletedTitleFollowing = await _titleFollowingRepository.DeleteAsync(titleFollowing);

        return deletedTitleFollowing;
    }
}
