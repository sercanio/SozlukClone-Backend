using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TitleSettingRepository : EfRepositoryBase<TitleSetting, int, BaseDbContext>, ITitleSettingRepository
{
    public TitleSettingRepository(BaseDbContext context) : base(context)
    {
    }
}