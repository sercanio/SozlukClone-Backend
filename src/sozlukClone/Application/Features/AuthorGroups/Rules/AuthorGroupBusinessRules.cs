using Application.Features.AuthorGroups.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AuthorGroups.Rules;

public class AuthorGroupBusinessRules : BaseBusinessRules
{
    private readonly IAuthorGroupRepository _authorGroupRepository;
    private readonly ILocalizationService _localizationService;

    public AuthorGroupBusinessRules(IAuthorGroupRepository authorGroupRepository, ILocalizationService localizationService)
    {
        _authorGroupRepository = authorGroupRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AuthorGroupsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AuthorGroupShouldExistWhenSelected(AuthorGroup? authorGroup)
    {
        if (authorGroup == null)
            await throwBusinessException(AuthorGroupsBusinessMessages.AuthorGroupNotExists);
    }

    public async Task AuthorGroupIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        AuthorGroup? authorGroup = await _authorGroupRepository.GetAsync(
            predicate: ag => ag.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AuthorGroupShouldExistWhenSelected(authorGroup);
    }
}