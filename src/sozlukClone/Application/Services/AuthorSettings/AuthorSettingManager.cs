using Application.Features.AuthorSettings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AuthorSettings;

public class AuthorSettingManager : IAuthorSettingService
{
    private readonly IAuthorSettingRepository _authorSettingRepository;
    private readonly AuthorSettingBusinessRules _authorSettingBusinessRules;

    public AuthorSettingManager(IAuthorSettingRepository authorSettingRepository, AuthorSettingBusinessRules authorSettingBusinessRules)
    {
        _authorSettingRepository = authorSettingRepository;
        _authorSettingBusinessRules = authorSettingBusinessRules;
    }

    public async Task<AuthorSetting?> GetAsync(
        Expression<Func<AuthorSetting, bool>> predicate,
        Func<IQueryable<AuthorSetting>, IIncludableQueryable<AuthorSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AuthorSetting? authorSetting = await _authorSettingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return authorSetting;
    }

    public async Task<IPaginate<AuthorSetting>?> GetListAsync(
        Expression<Func<AuthorSetting, bool>>? predicate = null,
        Func<IQueryable<AuthorSetting>, IOrderedQueryable<AuthorSetting>>? orderBy = null,
        Func<IQueryable<AuthorSetting>, IIncludableQueryable<AuthorSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AuthorSetting> authorSettingList = await _authorSettingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return authorSettingList;
    }

    public async Task<AuthorSetting> AddAsync(AuthorSetting authorSetting)
    {
        AuthorSetting addedAuthorSetting = await _authorSettingRepository.AddAsync(authorSetting);

        return addedAuthorSetting;
    }

    public async Task<AuthorSetting> UpdateAsync(AuthorSetting authorSetting)
    {
        AuthorSetting updatedAuthorSetting = await _authorSettingRepository.UpdateAsync(authorSetting);

        return updatedAuthorSetting;
    }

    public async Task<AuthorSetting> DeleteAsync(AuthorSetting authorSetting, bool permanent = false)
    {
        AuthorSetting deletedAuthorSetting = await _authorSettingRepository.DeleteAsync(authorSetting);

        return deletedAuthorSetting;
    }
}
