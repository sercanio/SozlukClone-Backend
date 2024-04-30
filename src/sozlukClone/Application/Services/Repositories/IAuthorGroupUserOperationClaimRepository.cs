using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAuthorGroupUserOperationClaimRepository : IAsyncRepository<AuthorGroupUserOperationClaim, Guid>, IRepository<AuthorGroupUserOperationClaim, Guid>
{
}