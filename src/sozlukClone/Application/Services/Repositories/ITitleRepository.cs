using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories
{
    public interface ITitleRepository : IAsyncRepository<Title, int>, IRepository<Title, int>
    {
    }
}
