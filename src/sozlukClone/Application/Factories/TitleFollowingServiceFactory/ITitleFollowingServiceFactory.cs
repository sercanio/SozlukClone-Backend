using Application.Services.TitleFollowings;

namespace Application.Factories.TitleFollowingServiceFactory;
public interface ITitleFollowingServiceFactory
{
    ITitleFollowingService Create();
}