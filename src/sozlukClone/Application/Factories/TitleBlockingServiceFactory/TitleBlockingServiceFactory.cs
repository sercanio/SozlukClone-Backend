using Application.Services.TitleBlockings;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Factories.TitleBlockingServiceFactory;

public class TitleBlockingServiceFactory : ITitleBlockingServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TitleBlockingServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITitleBlockingService Create()
    {
        return _serviceProvider.GetRequiredService<ITitleBlockingService>();
    }
}