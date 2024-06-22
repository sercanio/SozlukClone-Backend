using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleBlockingRepository : EfRepositoryBase<TitleBlocking, Guid, BaseDbContext>, ITitleBlockingRepository
{
    public TitleBlockingRepository(BaseDbContext context) : base(context)
    {
    }
}