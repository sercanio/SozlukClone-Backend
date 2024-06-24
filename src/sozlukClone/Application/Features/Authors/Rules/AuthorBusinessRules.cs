using Application.Features.Authors.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using System.Text.RegularExpressions;

namespace Application.Features.Authors.Rules;

public class AuthorBusinessRules : BaseBusinessRules
{
    private readonly IAuthorRepository _authorRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorBusinessRules(IAuthorRepository authorRepository, ILocalizationService localizationService)
    {
        _authorRepository = authorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorShouldExistWhenSelected(Author? author)
    {
        if (author == null)
            await throwBusinessException(AuthorsBusinessMessages.AuthorNotExists);
    }

    public async Task AuthorIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        Author? author = await _authorRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorShouldExistWhenSelected(author);
    }

    public async Task AuthorNameShouldExistWhenSelected(string name, CancellationToken cancellationToken)
    {
        Author? author = await _authorRepository.GetAsync(
            predicate: a => a.UserName == name,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorShouldExistWhenSelected(author);
    }

    public async Task AuthorUserNameShouldBeUnique(string userName)
    {
        Author? author = await _authorRepository.GetAsync(
                       predicate: a => a.UserName == userName,
                                  enableTracking: false
                                         );

        if (author != null)
            await throwBusinessException(AuthorsBusinessMessages.AuthorUserNameShouldBeUnique);
    }

    public async Task AuthorUserNameShouldOnlyHaveLettersAndNumbers(string userName)
    {
        Regex regex = new Regex(@"^[a-zA-Z0-9]+$");

        if (!regex.IsMatch(userName))
            await throwBusinessException(AuthorsBusinessMessages.AuthorUserNameShouldOnlyHaveLettersAndNumbers);
    }

    public async Task AuthorUserNameShouldHaveMinumumLength(string userName, byte minLength)
    {
        if (userName.Length < minLength)
            await throwBusinessException(AuthorsBusinessMessages.AuthorUserNameShouldHaveMinumumLength);
    }

    public async Task AuthorUserNameShouldHaveMaximumLength(string userName, byte maxLength)
    {
        if (userName.Length > maxLength)
            await throwBusinessException(AuthorsBusinessMessages.AuthorUserNameShouldHaveMaximumLength);
    }
}