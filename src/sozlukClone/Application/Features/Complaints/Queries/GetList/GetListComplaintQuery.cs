using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Complaints.Queries.GetList;

public class GetListComplaintQuery : IRequest<GetListResponse<GetListComplaintListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListComplaintQueryHandler : IRequestHandler<GetListComplaintQuery, GetListResponse<GetListComplaintListItemDto>>
    {
        private readonly IComplaintRepository _complaintRepository;
        private readonly IMapper _mapper;

        public GetListComplaintQueryHandler(IComplaintRepository complaintRepository, IMapper mapper)
        {
            _complaintRepository = complaintRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListComplaintListItemDto>> Handle(GetListComplaintQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Complaint> complaints = await _complaintRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListComplaintListItemDto> response = _mapper.Map<GetListResponse<GetListComplaintListItemDto>>(complaints);
            return response;
        }
    }
}