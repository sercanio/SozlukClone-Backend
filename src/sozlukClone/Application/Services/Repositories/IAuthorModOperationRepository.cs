using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorModOperationRepository : IAsyncRepository<AuthorModOperation, Guid>, IRepository<AuthorModOperation, Guid>
{
}