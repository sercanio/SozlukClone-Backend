using Application.Features.Titles.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using System.Text.RegularExpressions;

namespace Application.Features.Titles.Rules;

public class TitleBusinessRules : BaseBusinessRules
{
    private readonly ITitleRepository _titleRepository;
    private readonly ILocalizationService _localizationService;

    public TitleBusinessRules(ITitleRepository titleRepository, ILocalizationService localizationService)
    {
        _titleRepository = titleRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TitlesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TitleShouldExistWhenSelected(Title? title)
    {
        if (title == null)
            await throwBusinessException(TitlesBusinessMessages.TitleNotExists);
    }

    public async Task TitleIdShouldExistWhenSelected(uint id, CancellationToken cancellationToken)
    {
        Title? title = await _titleRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TitleShouldExistWhenSelected(title);
    }

    public async Task TitleNameShouldNotExistsWhenInsert(string name)
    {
        bool doesExist = await _titleRepository.AnyAsync(predicate: t => t.Name == name);
        if (doesExist)
            await throwBusinessException(TitlesBusinessMessages.TitleAlreadyExists);
    }

    public async Task TitleShouldHaveMinLength(string title, byte minLength)
    {
        if (title.Length < minLength)
            await throwBusinessException(TitlesBusinessMessages.TitleMinLength);
    }

    public async Task TitleShouldHaveMaxLength(string title, byte maxLength)
    {
        if (title.Length > maxLength)
            await throwBusinessException(TitlesBusinessMessages.TitleMaxLength);
    }

    public async Task TitleCanHaveSpecialCharachters(string title, bool canHaveSpecialCharachters)
    {
        if (!canHaveSpecialCharachters)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 ]"); // Allow only letters, numbers, and spaces

            if (regex.IsMatch(title))
            {
                await throwBusinessException(TitlesBusinessMessages.TitleCanNotHaveSpecialCharacters);
            }
        }
    }

    public async Task TitleCanHavePunctuations(string title, bool canHavePunctuations)
    {
        if (!canHavePunctuations)
        {
            // Define a regular expression pattern to match punctuations
            Regex regex = new Regex("[!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~]"); // List of common punctuations

            if (regex.IsMatch(title))
            {
                await throwBusinessException(TitlesBusinessMessages.TitleCanNotHavePunctuations);
            }
        }
    }

}