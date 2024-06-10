using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.GlobalSettings;

public interface IGlobalSettingService
{
    Task<GlobalSetting?> GetAsync(
        Expression<Func<GlobalSetting, bool>> predicate,
        Func<IQueryable<GlobalSetting>, IIncludableQueryable<GlobalSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<GlobalSetting>?> GetListAsync(
        Expression<Func<GlobalSetting, bool>>? predicate = null,
        Func<IQueryable<GlobalSetting>, IOrderedQueryable<GlobalSetting>>? orderBy = null,
        Func<IQueryable<GlobalSetting>, IIncludableQueryable<GlobalSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<GlobalSetting> AddAsync(GlobalSetting globalSetting);
    Task<GlobalSetting> UpdateAsync(GlobalSetting globalSetting);
    Task<GlobalSetting> DeleteAsync(GlobalSetting globalSetting, bool permanent = false);
}
