using Application.Features.TitleBlockings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleBlockings;

public class TitleBlockingManager : ITitleBlockingService
{
    private readonly ITitleBlockingRepository _titleBlockingRepository;
    private readonly TitleBlockingBusinessRules _titleBlockingBusinessRules;

    public TitleBlockingManager(ITitleBlockingRepository titleBlockingRepository, TitleBlockingBusinessRules titleBlockingBusinessRules)
    {
        _titleBlockingRepository = titleBlockingRepository;
        _titleBlockingBusinessRules = titleBlockingBusinessRules;
    }

    public async Task<TitleBlocking?> GetAsync(
        Expression<Func<TitleBlocking, bool>> predicate,
        Func<IQueryable<TitleBlocking>, IIncludableQueryable<TitleBlocking, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TitleBlocking? titleBlocking = await _titleBlockingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return titleBlocking;
    }

    public async Task<IPaginate<TitleBlocking>?> GetListAsync(
        Expression<Func<TitleBlocking, bool>>? predicate = null,
        Func<IQueryable<TitleBlocking>, IOrderedQueryable<TitleBlocking>>? orderBy = null,
        Func<IQueryable<TitleBlocking>, IIncludableQueryable<TitleBlocking, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TitleBlocking> titleBlockingList = await _titleBlockingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return titleBlockingList;
    }

    public async Task<TitleBlocking> AddAsync(TitleBlocking titleBlocking)
    {
        TitleBlocking addedTitleBlocking = await _titleBlockingRepository.AddAsync(titleBlocking);

        return addedTitleBlocking;
    }

    public async Task<TitleBlocking> UpdateAsync(TitleBlocking titleBlocking)
    {
        TitleBlocking updatedTitleBlocking = await _titleBlockingRepository.UpdateAsync(titleBlocking);

        return updatedTitleBlocking;
    }

    public async Task<TitleBlocking> DeleteAsync(TitleBlocking titleBlocking, bool permanent = false)
    {
        TitleBlocking deletedTitleBlocking = await _titleBlockingRepository.DeleteAsync(titleBlocking);

        return deletedTitleBlocking;
    }
}
