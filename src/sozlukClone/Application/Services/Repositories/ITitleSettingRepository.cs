using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITitleSettingRepository : IAsyncRepository<TitleSetting, int>, IRepository<TitleSetting, int>
{
}