using Application.Features.Dislikes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Dislikes;

public class DislikeManager : IDislikeService
{
    private readonly IDislikeRepository _dislikeRepository;
    private readonly DislikeBusinessRules _dislikeBusinessRules;

    public DislikeManager(IDislikeRepository dislikeRepository, DislikeBusinessRules dislikeBusinessRules)
    {
        _dislikeRepository = dislikeRepository;
        _dislikeBusinessRules = dislikeBusinessRules;
    }

    public async Task<Dislike?> GetAsync(
        Expression<Func<Dislike, bool>> predicate,
        Func<IQueryable<Dislike>, IIncludableQueryable<Dislike, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Dislike? dislike = await _dislikeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return dislike;
    }

    public async Task<IPaginate<Dislike>?> GetListAsync(
        Expression<Func<Dislike, bool>>? predicate = null,
        Func<IQueryable<Dislike>, IOrderedQueryable<Dislike>>? orderBy = null,
        Func<IQueryable<Dislike>, IIncludableQueryable<Dislike, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Dislike> dislikeList = await _dislikeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return dislikeList;
    }

    public async Task<Dislike> AddAsync(Dislike dislike)
    {
        Dislike addedDislike = await _dislikeRepository.AddAsync(dislike);

        return addedDislike;
    }

    public async Task<Dislike> UpdateAsync(Dislike dislike)
    {
        Dislike updatedDislike = await _dislikeRepository.UpdateAsync(dislike);

        return updatedDislike;
    }

    public async Task<Dislike> DeleteAsync(Dislike dislike, bool permanent = false)
    {
        Dislike deletedDislike = await _dislikeRepository.DeleteAsync(dislike);

        return deletedDislike;
    }
}
