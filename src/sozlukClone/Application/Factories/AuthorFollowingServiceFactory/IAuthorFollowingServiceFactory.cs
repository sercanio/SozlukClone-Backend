using Application.Services.AuthorFollowings;

namespace Application.Factories.AuthorBlockingServiceFactory;

public interface IAuthorFollowingServiceFactory
{
    IAuthorFollowingService Create();
}
