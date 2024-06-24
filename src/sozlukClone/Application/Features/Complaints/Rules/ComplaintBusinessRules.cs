using Application.Features.Complaints.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Complaints.Rules;

public class ComplaintBusinessRules : BaseBusinessRules
{
    private readonly IComplaintRepository _complaintRepository;
    private readonly ILocalizationService _localizationService;

    public ComplaintBusinessRules(IComplaintRepository complaintRepository, ILocalizationService localizationService)
    {
        _complaintRepository = complaintRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ComplaintsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ComplaintShouldExistWhenSelected(Complaint? complaint)
    {
        if (complaint == null)
            await throwBusinessException(ComplaintsBusinessMessages.ComplaintNotExists);
    }

    public async Task ComplaintIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Complaint? complaint = await _complaintRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ComplaintShouldExistWhenSelected(complaint);
    }
}