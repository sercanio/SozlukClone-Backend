using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Titles;

public class TitleManager : ITitleService
{
    private readonly ITitleRepository _titleRepository;
    private readonly TitleBusinessRules _titleBusinessRules;

    public TitleManager(ITitleRepository titleRepository, TitleBusinessRules titleBusinessRules)
    {
        _titleRepository = titleRepository;
        _titleBusinessRules = titleBusinessRules;
    }

    public async Task<Title?> GetAsync(
        Expression<Func<Title, bool>> predicate,
        Func<IQueryable<Title>, IIncludableQueryable<Title, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Title? title = await _titleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return title;
    }

    public async Task<IPaginate<Title>?> GetListAsync(
        Expression<Func<Title, bool>>? predicate = null,
        Func<IQueryable<Title>, IOrderedQueryable<Title>>? orderBy = null,
        Func<IQueryable<Title>, IIncludableQueryable<Title, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Title> titleList = await _titleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return titleList;
    }

    public async Task<Title> AddAsync(Title title)
    {
        Title addedTitle = await _titleRepository.AddAsync(title);

        return addedTitle;
    }

    public async Task<Title> UpdateAsync(Title title)
    {
        Title updatedTitle = await _titleRepository.UpdateAsync(title);

        return updatedTitle;
    }

    public async Task<Title> DeleteAsync(Title title, bool permanent = false)
    {
        Title deletedTitle = await _titleRepository.DeleteAsync(title);

        return deletedTitle;
    }
}
