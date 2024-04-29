using Application.Features.RegisterAudits.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.RegisterAudits.Constants.RegisterAuditsOperationClaims;

namespace Application.Features.RegisterAudits.Queries.GetList;

public class GetListRegisterAuditQuery : IRequest<GetListResponse<GetListRegisterAuditListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListRegisterAuditQueryHandler : IRequestHandler<GetListRegisterAuditQuery, GetListResponse<GetListRegisterAuditListItemDto>>
    {
        private readonly IRegisterAuditRepository _registerAuditRepository;
        private readonly IMapper _mapper;

        public GetListRegisterAuditQueryHandler(IRegisterAuditRepository registerAuditRepository, IMapper mapper)
        {
            _registerAuditRepository = registerAuditRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRegisterAuditListItemDto>> Handle(GetListRegisterAuditQuery request, CancellationToken cancellationToken)
        {
            IPaginate<RegisterAudit> registerAudits = await _registerAuditRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRegisterAuditListItemDto> response = _mapper.Map<GetListResponse<GetListRegisterAuditListItemDto>>(registerAudits);
            return response;
        }
    }
}