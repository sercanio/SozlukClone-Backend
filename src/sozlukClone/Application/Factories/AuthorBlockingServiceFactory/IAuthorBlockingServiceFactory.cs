using Application.Services.AuthorBlockings;

namespace Application.Factories.AuthorBlockingServiceFactory;

public interface IAuthorBlockingServiceFactory
{
    IAuthorBlockingService Create();
}
