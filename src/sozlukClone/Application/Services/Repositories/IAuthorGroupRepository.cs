using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorGroupRepository : IAsyncRepository<AuthorGroup, uint>, IRepository<AuthorGroup, uint>
{
}