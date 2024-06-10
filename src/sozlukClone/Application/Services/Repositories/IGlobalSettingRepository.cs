using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGlobalSettingRepository : IAsyncRepository<GlobalSetting, int>, IRepository<GlobalSetting, int>
{
    Task<int> GetAsyncCount();
}