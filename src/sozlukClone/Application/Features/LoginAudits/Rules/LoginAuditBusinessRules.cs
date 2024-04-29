using Application.Features.LoginAudits.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.LoginAudits.Rules;

public class LoginAuditBusinessRules : BaseBusinessRules
{
    private readonly ILoginAuditRepository _loginAuditRepository;
    private readonly ILocalizationService _localizationService;

    public LoginAuditBusinessRules(ILoginAuditRepository loginAuditRepository, ILocalizationService localizationService)
    {
        _loginAuditRepository = loginAuditRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LoginAuditsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LoginAuditShouldExistWhenSelected(LoginAudit? loginAudit)
    {
        if (loginAudit == null)
            await throwBusinessException(LoginAuditsBusinessMessages.LoginAuditNotExists);
    }

    public async Task LoginAuditIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        LoginAudit? loginAudit = await _loginAuditRepository.GetAsync(
            predicate: la => la.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LoginAuditShouldExistWhenSelected(loginAudit);
    }
}