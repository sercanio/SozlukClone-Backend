using Application.Features.LoginAudits.Constants;
using Application.Features.LoginAudits.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.LoginAudits.Constants.LoginAuditsOperationClaims;

namespace Application.Features.LoginAudits.Queries.GetById;

public class GetByIdLoginAuditQuery : IRequest<GetByIdLoginAuditResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdLoginAuditQueryHandler : IRequestHandler<GetByIdLoginAuditQuery, GetByIdLoginAuditResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILoginAuditRepository _loginAuditRepository;
        private readonly LoginAuditBusinessRules _loginAuditBusinessRules;

        public GetByIdLoginAuditQueryHandler(IMapper mapper, ILoginAuditRepository loginAuditRepository, LoginAuditBusinessRules loginAuditBusinessRules)
        {
            _mapper = mapper;
            _loginAuditRepository = loginAuditRepository;
            _loginAuditBusinessRules = loginAuditBusinessRules;
        }

        public async Task<GetByIdLoginAuditResponse> Handle(GetByIdLoginAuditQuery request, CancellationToken cancellationToken)
        {
            LoginAudit? loginAudit = await _loginAuditRepository.GetAsync(predicate: la => la.Id == request.Id, cancellationToken: cancellationToken);
            await _loginAuditBusinessRules.LoginAuditShouldExistWhenSelected(loginAudit);

            GetByIdLoginAuditResponse response = _mapper.Map<GetByIdLoginAuditResponse>(loginAudit);
            return response;
        }
    }
}