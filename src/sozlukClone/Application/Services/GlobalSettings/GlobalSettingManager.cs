using Application.Features.GlobalSettings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GlobalSettings;

public class GlobalSettingManager : IGlobalSettingService
{
    private readonly IGlobalSettingRepository _globalSettingRepository;
    private readonly GlobalSettingBusinessRules _globalSettingBusinessRules;

    public GlobalSettingManager(IGlobalSettingRepository globalSettingRepository, GlobalSettingBusinessRules globalSettingBusinessRules)
    {
        _globalSettingRepository = globalSettingRepository;
        _globalSettingBusinessRules = globalSettingBusinessRules;
    }

    public async Task<GlobalSetting?> GetAsync(
        Expression<Func<GlobalSetting, bool>> predicate,
        Func<IQueryable<GlobalSetting>, IIncludableQueryable<GlobalSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        GlobalSetting? globalSetting = await _globalSettingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return globalSetting;
    }

    public async Task<IPaginate<GlobalSetting>?> GetListAsync(
        Expression<Func<GlobalSetting, bool>>? predicate = null,
        Func<IQueryable<GlobalSetting>, IOrderedQueryable<GlobalSetting>>? orderBy = null,
        Func<IQueryable<GlobalSetting>, IIncludableQueryable<GlobalSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<GlobalSetting> globalSettingList = await _globalSettingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return globalSettingList;
    }

    public async Task<GlobalSetting> AddAsync(GlobalSetting globalSetting)
    {
        GlobalSetting addedGlobalSetting = await _globalSettingRepository.AddAsync(globalSetting);

        return addedGlobalSetting;
    }

    public async Task<GlobalSetting> UpdateAsync(GlobalSetting globalSetting)
    {
        GlobalSetting updatedGlobalSetting = await _globalSettingRepository.UpdateAsync(globalSetting);

        return updatedGlobalSetting;
    }

    public async Task<GlobalSetting> DeleteAsync(GlobalSetting globalSetting, bool permanent = false)
    {
        GlobalSetting deletedGlobalSetting = await _globalSettingRepository.DeleteAsync(globalSetting);

        return deletedGlobalSetting;
    }
}
