using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorBlockingRepository : IAsyncRepository<AuthorBlocking, Guid>, IRepository<AuthorBlocking, Guid>
{
}