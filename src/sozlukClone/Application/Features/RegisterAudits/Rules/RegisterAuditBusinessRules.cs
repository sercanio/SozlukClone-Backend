using Application.Features.RegisterAudits.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RegisterAudits.Rules;

public class RegisterAuditBusinessRules : BaseBusinessRules
{
    private readonly IRegisterAuditRepository _registerAuditRepository;
    private readonly ILocalizationService _localizationService;

    public RegisterAuditBusinessRules(IRegisterAuditRepository registerAuditRepository, ILocalizationService localizationService)
    {
        _registerAuditRepository = registerAuditRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RegisterAuditsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RegisterAuditShouldExistWhenSelected(RegisterAudit? registerAudit)
    {
        if (registerAudit == null)
            await throwBusinessException(RegisterAuditsBusinessMessages.RegisterAuditNotExists);
    }

    public async Task RegisterAuditIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RegisterAudit? registerAudit = await _registerAuditRepository.GetAsync(
            predicate: ra => ra.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RegisterAuditShouldExistWhenSelected(registerAudit);
    }
}