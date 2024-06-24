using Application.Features.Complaints.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Complaints.Queries.GetById;

public class GetByIdComplaintQuery : IRequest<GetByIdComplaintResponse>
{
    public Guid Id { get; set; }

    public class GetByIdComplaintQueryHandler : IRequestHandler<GetByIdComplaintQuery, GetByIdComplaintResponse>
    {
        private readonly IMapper _mapper;
        private readonly IComplaintRepository _complaintRepository;
        private readonly ComplaintBusinessRules _complaintBusinessRules;

        public GetByIdComplaintQueryHandler(IMapper mapper, IComplaintRepository complaintRepository, ComplaintBusinessRules complaintBusinessRules)
        {
            _mapper = mapper;
            _complaintRepository = complaintRepository;
            _complaintBusinessRules = complaintBusinessRules;
        }

        public async Task<GetByIdComplaintResponse> Handle(GetByIdComplaintQuery request, CancellationToken cancellationToken)
        {
            Complaint? complaint = await _complaintRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _complaintBusinessRules.ComplaintShouldExistWhenSelected(complaint);

            GetByIdComplaintResponse response = _mapper.Map<GetByIdComplaintResponse>(complaint);
            return response;
        }
    }
}