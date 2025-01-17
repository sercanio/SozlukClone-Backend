using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("BaseDb")));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IAuthorGroupRepository, AuthorGroupRepository>();
        services.AddScoped<IBadgeRepository, BadgeRepository>();
        services.AddScoped<IEntryRepository, EntryRepository>();
        services.AddScoped<IPenaltyRepository, PenaltyRepository>();
        services.AddScoped<ITitleRepository, TitleRepository>();

        services.AddScoped<IPenaltyTypeRepository, PenaltyTypeRepository>();
        services.AddScoped<ILoginAuditRepository, LoginAuditRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<ITitleSettingRepository, TitleSettingRepository>();
        services.AddScoped<IAuthorSettingRepository, AuthorSettingRepository>();
        services.AddScoped<IAuthorGroupUserOperationClaimRepository, AuthorGroupUserOperationClaimRepository>();
        services.AddScoped<IGlobalSettingRepository, GlobalSettingRepository>();
        services.AddScoped<ILikeRepository, LikeRepository>();
        services.AddScoped<IDislikeRepository, DislikeRepository>();
        services.AddScoped<IFavoriteRepository, FavoriteRepository>();
        services.AddScoped<IAuthorBlockingRepository, AuthorBlockingRepository>();
        services.AddScoped<IAuthorFollowingRepository, AuthorFollowingRepository>();
        services.AddScoped<IAuthorModOperationRepository, AuthorModOperationRepository>();
        services.AddScoped<IEntryModOperationRepository, EntryModOperationRepository>();
        services.AddScoped<ITitleBlockingRepository, TitleBlockingRepository>();
        services.AddScoped<ITitleFollowingRepository, TitleFollowingRepository>();
        services.AddScoped<ITitleModOperationRepository, TitleModOperationRepository>();
        services.AddScoped<IAuthorBlockingRepository, AuthorBlockingRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IComplaintRepository, ComplaintRepository>();
        return services;
    }
}
