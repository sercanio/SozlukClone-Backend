using Application.Features.Complaints.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Complaints.Commands.Update;

public class UpdateComplaintCommand : IRequest<UpdatedComplaintResponse>
{
    public Guid Id { get; set; }
    public required int TitleId { get; set; }
    public int? EntryId { get; set; }
    public required string Details { get; set; }
    public required ComplaintStatusEnum Status { get; set; }
    public int? AuthorId { get; set; }
    public string? Email { get; set; }

    public class UpdateComplaintCommandHandler : IRequestHandler<UpdateComplaintCommand, UpdatedComplaintResponse>
    {
        private readonly IMapper _mapper;
        private readonly IComplaintRepository _complaintRepository;
        private readonly ComplaintBusinessRules _complaintBusinessRules;

        public UpdateComplaintCommandHandler(IMapper mapper, IComplaintRepository complaintRepository,
                                         ComplaintBusinessRules complaintBusinessRules)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _complaintBusinessRules = complaintBusinessRules;
        }

        public async Task<UpdatedComplaintResponse> Handle(UpdateComplaintCommand request, CancellationToken cancellationToken)
        {
            Complaint? complaint = await _complaintRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _complaintBusinessRules.ComplaintShouldExistWhenSelected(complaint);
            complaint = _mapper.Map(request, complaint);

            await _complaintRepository.UpdateAsync(complaint!);

            UpdatedComplaintResponse response = _mapper.Map<UpdatedComplaintResponse>(complaint);
            return response;
        }
    }
}