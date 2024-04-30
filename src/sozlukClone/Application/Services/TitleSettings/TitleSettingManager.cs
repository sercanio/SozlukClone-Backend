using Application.Features.TitleSettings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleSettings;

public class TitleSettingManager : ITitleSettingService
{
    private readonly ITitleSettingRepository _titleSettingRepository;
    private readonly TitleSettingBusinessRules _titleSettingBusinessRules;

    public TitleSettingManager(ITitleSettingRepository titleSettingRepository, TitleSettingBusinessRules titleSettingBusinessRules)
    {
        _titleSettingRepository = titleSettingRepository;
        _titleSettingBusinessRules = titleSettingBusinessRules;
    }

    public async Task<TitleSetting?> GetAsync(
        Expression<Func<TitleSetting, bool>> predicate,
        Func<IQueryable<TitleSetting>, IIncludableQueryable<TitleSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TitleSetting? titleSetting = await _titleSettingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return titleSetting;
    }

    public async Task<IPaginate<TitleSetting>?> GetListAsync(
        Expression<Func<TitleSetting, bool>>? predicate = null,
        Func<IQueryable<TitleSetting>, IOrderedQueryable<TitleSetting>>? orderBy = null,
        Func<IQueryable<TitleSetting>, IIncludableQueryable<TitleSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TitleSetting> titleSettingList = await _titleSettingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return titleSettingList;
    }

    public async Task<TitleSetting> AddAsync(TitleSetting titleSetting)
    {
        TitleSetting addedTitleSetting = await _titleSettingRepository.AddAsync(titleSetting);

        return addedTitleSetting;
    }

    public async Task<TitleSetting> UpdateAsync(TitleSetting titleSetting)
    {
        TitleSetting updatedTitleSetting = await _titleSettingRepository.UpdateAsync(titleSetting);

        return updatedTitleSetting;
    }

    public async Task<TitleSetting> DeleteAsync(TitleSetting titleSetting, bool permanent = false)
    {
        TitleSetting deletedTitleSetting = await _titleSettingRepository.DeleteAsync(titleSetting);

        return deletedTitleSetting;
    }
}
