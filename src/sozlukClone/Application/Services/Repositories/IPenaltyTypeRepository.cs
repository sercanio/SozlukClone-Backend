using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPenaltyTypeRepository : IAsyncRepository<PenaltyType, int>, IRepository<PenaltyType, int>
{
}