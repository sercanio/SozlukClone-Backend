using Application.Services.AuthorBlockings;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories.AuthorBlockingServiceFactory;

public class AuthorBlockingServiceFactory : IAuthorBlockingServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public AuthorBlockingServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IAuthorBlockingService Create()
    {
        return _serviceProvider.GetRequiredService<IAuthorBlockingService>();
    }
}