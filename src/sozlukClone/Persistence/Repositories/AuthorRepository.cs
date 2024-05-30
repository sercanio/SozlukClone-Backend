using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class AuthorRepository : EfRepositoryBase<Author, int, BaseDbContext>, IAuthorRepository
{
    private readonly BaseDbContext _context;
    public AuthorRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Author> GetAuthorByUserIdAsync(Expression<Func<Author, bool>> predicate, Func<IQueryable<Author>, IIncludableQueryable<Author, object>>? include = null, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default(CancellationToken))
    {
        IQueryable<Author> queryable = Query();
        if (!enableTracking)
        {
            queryable = queryable.AsNoTracking();
        }

        if (include != null)
        {
            queryable = include(queryable);
        }

        if (withDeleted)
        {
            queryable = queryable.IgnoreQueryFilters();
        }

        Author? author = await queryable.FirstOrDefaultAsync(predicate, cancellationToken);

        return author;
    }
}