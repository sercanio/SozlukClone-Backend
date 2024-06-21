using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRelationRepository : IAsyncRepository<Relation, Guid>, IRepository<Relation, Guid>
{
}