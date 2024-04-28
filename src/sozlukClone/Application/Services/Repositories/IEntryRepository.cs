using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEntryRepository : IAsyncRepository<Entry, uint>, IRepository<Entry, uint>
{
}