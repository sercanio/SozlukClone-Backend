using Application.Features.Relations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Relations;

public class RelationManager : IRelationService
{
    private readonly IRelationRepository _relationRepository;
    private readonly RelationBusinessRules _relationBusinessRules;

    public RelationManager(IRelationRepository relationRepository, RelationBusinessRules relationBusinessRules)
    {
        _relationRepository = relationRepository;
        _relationBusinessRules = relationBusinessRules;
    }

    public async Task<Relation?> GetAsync(
        Expression<Func<Relation, bool>> predicate,
        Func<IQueryable<Relation>, IIncludableQueryable<Relation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Relation? relation = await _relationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return relation;
    }

    public async Task<IPaginate<Relation>?> GetListAsync(
        Expression<Func<Relation, bool>>? predicate = null,
        Func<IQueryable<Relation>, IOrderedQueryable<Relation>>? orderBy = null,
        Func<IQueryable<Relation>, IIncludableQueryable<Relation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Relation> relationList = await _relationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return relationList;
    }

    public async Task<Relation> AddAsync(Relation relation)
    {
        Relation addedRelation = await _relationRepository.AddAsync(relation);

        return addedRelation;
    }

    public async Task<Relation> UpdateAsync(Relation relation)
    {
        Relation updatedRelation = await _relationRepository.UpdateAsync(relation);

        return updatedRelation;
    }

    public async Task<Relation> DeleteAsync(Relation relation, bool permanent = false)
    {
        Relation deletedRelation = await _relationRepository.DeleteAsync(relation);

        return deletedRelation;
    }
}
