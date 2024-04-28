using Application.Features.PenaltyTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PenaltyTypes;

public class PenaltyTypeManager : IPenaltyTypeService
{
    private readonly IPenaltyTypeRepository _penaltyTypeRepository;
    private readonly PenaltyTypeBusinessRules _penaltyTypeBusinessRules;

    public PenaltyTypeManager(IPenaltyTypeRepository penaltyTypeRepository, PenaltyTypeBusinessRules penaltyTypeBusinessRules)
    {
        _penaltyTypeRepository = penaltyTypeRepository;
        _penaltyTypeBusinessRules = penaltyTypeBusinessRules;
    }

    public async Task<PenaltyType?> GetAsync(
        Expression<Func<PenaltyType, bool>> predicate,
        Func<IQueryable<PenaltyType>, IIncludableQueryable<PenaltyType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PenaltyType? penaltyType = await _penaltyTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return penaltyType;
    }

    public async Task<IPaginate<PenaltyType>?> GetListAsync(
        Expression<Func<PenaltyType, bool>>? predicate = null,
        Func<IQueryable<PenaltyType>, IOrderedQueryable<PenaltyType>>? orderBy = null,
        Func<IQueryable<PenaltyType>, IIncludableQueryable<PenaltyType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PenaltyType> penaltyTypeList = await _penaltyTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return penaltyTypeList;
    }

    public async Task<PenaltyType> AddAsync(PenaltyType penaltyType)
    {
        PenaltyType addedPenaltyType = await _penaltyTypeRepository.AddAsync(penaltyType);

        return addedPenaltyType;
    }

    public async Task<PenaltyType> UpdateAsync(PenaltyType penaltyType)
    {
        PenaltyType updatedPenaltyType = await _penaltyTypeRepository.UpdateAsync(penaltyType);

        return updatedPenaltyType;
    }

    public async Task<PenaltyType> DeleteAsync(PenaltyType penaltyType, bool permanent = false)
    {
        PenaltyType deletedPenaltyType = await _penaltyTypeRepository.DeleteAsync(penaltyType);

        return deletedPenaltyType;
    }
}
