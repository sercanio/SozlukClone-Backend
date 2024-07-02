using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PenaltyTypeRepository : EfRepositoryBase<PenaltyType, int, BaseDbContext>, IPenaltyTypeRepository
{
    public PenaltyTypeRepository(BaseDbContext context) : base(context)
    {
    }
}