using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class TitleRepository : EfRepositoryBase<Title, int, BaseDbContext>, ITitleRepository
    {
        public TitleRepository(BaseDbContext context) : base(context)
        {
        }
    }
}