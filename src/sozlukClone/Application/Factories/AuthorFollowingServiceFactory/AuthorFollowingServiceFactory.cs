using Application.Factories.AuthorBlockingServiceFactory;
using Application.Services.AuthorFollowings;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories.AuthorFollowingServiceFactory;

public class AuthorFollowingServiceFactory : IAuthorFollowingServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public AuthorFollowingServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAuthorFollowingService Create()
    {
        return _serviceProvider.GetRequiredService<IAuthorFollowingService>();
    }
}