using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDislikeRepository : IAsyncRepository<Dislike, Guid>, IRepository<Dislike, Guid>
{
}