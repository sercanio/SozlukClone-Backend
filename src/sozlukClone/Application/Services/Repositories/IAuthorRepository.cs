using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Repositories;
using System.Linq.Expressions;

namespace Application.Services.Repositories;

public interface IAuthorRepository : IAsyncRepository<Author, int>, IRepository<Author, int>
{
    Task<Author> GetAuthorByUserIdAsync(Expression<Func<Author, bool>> predicate, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken));
}