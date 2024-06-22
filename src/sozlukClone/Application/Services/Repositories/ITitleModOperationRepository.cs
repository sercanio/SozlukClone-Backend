using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleModOperationRepository : IAsyncRepository<TitleModOperation, Guid>, IRepository<TitleModOperation, Guid>
{
}