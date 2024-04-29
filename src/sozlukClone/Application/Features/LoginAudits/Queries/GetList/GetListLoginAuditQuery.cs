using Application.Features.LoginAudits.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.LoginAudits.Constants.LoginAuditsOperationClaims;

namespace Application.Features.LoginAudits.Queries.GetList;

public class GetListLoginAuditQuery : IRequest<GetListResponse<GetListLoginAuditListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListLoginAuditQueryHandler : IRequestHandler<GetListLoginAuditQuery, GetListResponse<GetListLoginAuditListItemDto>>
    {
        private readonly ILoginAuditRepository _loginAuditRepository;
        private readonly IMapper _mapper;

        public GetListLoginAuditQueryHandler(ILoginAuditRepository loginAuditRepository, IMapper mapper)
        {
            _loginAuditRepository = loginAuditRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLoginAuditListItemDto>> Handle(GetListLoginAuditQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LoginAudit> loginAudits = await _loginAuditRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLoginAuditListItemDto> response = _mapper.Map<GetListResponse<GetListLoginAuditListItemDto>>(loginAudits);
            return response;
        }
    }
}