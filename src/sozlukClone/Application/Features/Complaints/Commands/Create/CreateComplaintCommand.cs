using Application.Features.Complaints.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Complaints.Commands.Create;

public class CreateComplaintCommand : IRequest<CreatedComplaintResponse>
{
    public required int TitleId { get; set; }
    public int? EntryId { get; set; }
    public required string Details { get; set; }
    public required ComplaintStatusEnum Status { get; set; }
    public int? AuthorId { get; set; }
    public string? Email { get; set; }

    public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, CreatedComplaintResponse>
    {
        private readonly IMapper _mapper;
        private readonly IComplaintRepository _complaintRepository;
        private readonly ComplaintBusinessRules _complaintBusinessRules;

        public CreateComplaintCommandHandler(IMapper mapper, IComplaintRepository complaintRepository,
                                         ComplaintBusinessRules complaintBusinessRules)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _complaintBusinessRules = complaintBusinessRules;
        }

        public async Task<CreatedComplaintResponse> Handle(CreateComplaintCommand request, CancellationToken cancellationToken)
        {
            Complaint complaint = _mapper.Map<Complaint>(request);

            await _complaintRepository.AddAsync(complaint);

            CreatedComplaintResponse response = _mapper.Map<CreatedComplaintResponse>(complaint);
            return response;
        }
    }
}