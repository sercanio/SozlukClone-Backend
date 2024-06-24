using Application.Factories.AuthorBlockingServiceFactory;
using Application.Factories.AuthorFollowingServiceFactory;
using Application.Factories.DislikeServiceFactory;
using Application.Factories.FavoriteServiceFactory;
using Application.Factories.LikeServiceFactory;
using Application.Factories.TitleBlockingServiceFactory;
using Application.Factories.TitleFollowingServiceFactory;
using Application.Services.AuthenticatorService;
using Application.Services.AuthorBlockings;
using Application.Services.AuthorFollowings;
using Application.Services.AuthorGroups;
using Application.Services.AuthorGroupUserOperationClaims;
using Application.Services.AuthorModOperations;
using Application.Services.Authors;
using Application.Services.AuthorSettings;
using Application.Services.AuthService;
using Application.Services.Badges;
using Application.Services.Categories;
using Application.Services.Dislikes;
using Application.Services.Entries;
using Application.Services.EntryModOperations;
using Application.Services.Favorites;
using Application.Services.GlobalSettings;
using Application.Services.Likes;
using Application.Services.LoginAudits;
using Application.Services.Penalties;
using Application.Services.PenaltyTypes;
using Application.Services.TitleBlockings;
using Application.Services.TitleFollowings;
using Application.Services.TitleModOperations;
using Application.Services.Titles;
using Application.Services.TitleSettings;
using Application.Services.UserOperationClaims;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using System.Reflection;
using Application.Services.Complaints;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int, Guid>(tokenOptions);

        services.AddScoped<IAuthorGroupService, AuthorGroupManager>();
        services.AddScoped<IBadgeService, BadgeManager>();
        services.AddScoped<IEntryService, EntryManager>();
        services.AddScoped<IPenaltyService, PenaltyManager>();
        services.AddScoped<IPenaltyTypeService, PenaltyTypeManager>();
        services.AddScoped<ILoginAuditService, LoginAuditManager>();
        services.AddScoped<IAuthorService, AuthorManager>();
        services.AddScoped<ITitleService, TitleManager>();
        services.AddScoped<ITitleSettingService, TitleSettingManager>();
        services.AddScoped<IAuthorSettingService, AuthorSettingManager>();
        services.AddScoped<IAuthorGroupUserOperationClaimService, AuthorGroupUserOperationClaimManager>();
        services.AddScoped<IUserOperationClaimService, UserUserOperationClaimManager>();
        services.AddScoped<IGlobalSettingService, GlobalSettingManager>();
        services.AddScoped<IEntryService, EntryManager>();
        services.AddScoped<IEntryService, EntryManager>();
        services.AddScoped<IEntryService, EntryManager>();
        services.AddScoped<IEntryService, EntryManager>();
        services.AddScoped<ITitleService, TitleManager>();
        services.AddScoped<IEntryService, EntryManager>();
        services.AddScoped<ITitleService, TitleManager>();
        services.AddScoped<IEntryService, EntryManager>();
        services.AddScoped<ILikeService, LikeManager>();
        services.AddScoped<IDislikeService, DislikeManager>();
        services.AddScoped<IFavoriteService, FavoriteManager>();
        services.AddScoped<IAuthorBlockingService, AuthorBlockingManager>();
        services.AddScoped<IAuthorFollowingService, AuthorFollowingManager>();
        services.AddScoped<IAuthorModOperationService, AuthorModOperationManager>();
        services.AddScoped<IEntryModOperationService, EntryModOperationManager>();
        services.AddScoped<ITitleModOperationService, TitleModOperationManager>();
        services.AddScoped<IAuthorBlockingService, AuthorBlockingManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ITitleFollowingService, TitleFollowingManager>();
        services.AddScoped<ITitleBlockingService, TitleBlockingManager>();
        services.AddScoped<ITitleBlockingServiceFactory, TitleBlockingServiceFactory>();
        services.AddScoped<ITitleFollowingServiceFactory, TitleFollowingServiceFactory>();
        services.AddScoped<ILikeServiceFactory, LikeServiceFactory>();
        services.AddScoped<IDislikeServiceFactory, DislikeServiceFactory>();
        services.AddScoped<IFavoriteServiceFactory, FavoriteServiceFactory>();
        services.AddScoped<IAuthorFollowingServiceFactory, AuthorFollowingServiceFactory>();
        services.AddScoped<IAuthorBlockingServiceFactory, AuthorBlockingServiceFactory>();
        services.AddScoped<IComplaintService, ComplaintManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
