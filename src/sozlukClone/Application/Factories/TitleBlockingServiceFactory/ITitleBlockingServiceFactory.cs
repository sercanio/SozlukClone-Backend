using Application.Services.TitleBlockings;

namespace Application.Factories.TitleBlockingServiceFactory;

public interface ITitleBlockingServiceFactory
{
    ITitleBlockingService Create();
}

