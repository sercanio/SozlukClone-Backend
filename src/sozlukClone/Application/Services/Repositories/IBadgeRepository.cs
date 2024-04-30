using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBadgeRepository : IAsyncRepository<Badge, int>, IRepository<Badge, int>
{
}