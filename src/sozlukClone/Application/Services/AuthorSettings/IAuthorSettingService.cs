using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorSettings;

public interface IAuthorSettingService
{
    Task<AuthorSetting?> GetAsync(
        Expression<Func<AuthorSetting, bool>> predicate,
        Func<IQueryable<AuthorSetting>, IIncludableQueryable<AuthorSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AuthorSetting>?> GetListAsync(
        Expression<Func<AuthorSetting, bool>>? predicate = null,
        Func<IQueryable<AuthorSetting>, IOrderedQueryable<AuthorSetting>>? orderBy = null,
        Func<IQueryable<AuthorSetting>, IIncludableQueryable<AuthorSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AuthorSetting> AddAsync(AuthorSetting authorSetting);
    Task<AuthorSetting> UpdateAsync(AuthorSetting authorSetting);
    Task<AuthorSetting> DeleteAsync(AuthorSetting authorSetting, bool permanent = false);
}
