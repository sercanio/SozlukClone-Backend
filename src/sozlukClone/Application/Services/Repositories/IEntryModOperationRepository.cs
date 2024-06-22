using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEntryModOperationRepository : IAsyncRepository<EntryModOperation, Guid>, IRepository<EntryModOperation, Guid>
{
}