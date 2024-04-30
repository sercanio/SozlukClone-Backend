using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TitleSettings;

public interface ITitleSettingService
{
    Task<TitleSetting?> GetAsync(
        Expression<Func<TitleSetting, bool>> predicate,
        Func<IQueryable<TitleSetting>, IIncludableQueryable<TitleSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TitleSetting>?> GetListAsync(
        Expression<Func<TitleSetting, bool>>? predicate = null,
        Func<IQueryable<TitleSetting>, IOrderedQueryable<TitleSetting>>? orderBy = null,
        Func<IQueryable<TitleSetting>, IIncludableQueryable<TitleSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TitleSetting> AddAsync(TitleSetting titleSetting);
    Task<TitleSetting> UpdateAsync(TitleSetting titleSetting);
    Task<TitleSetting> DeleteAsync(TitleSetting titleSetting, bool permanent = false);
}
