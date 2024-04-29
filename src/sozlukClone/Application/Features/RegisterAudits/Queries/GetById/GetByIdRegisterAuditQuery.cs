using Application.Features.RegisterAudits.Constants;
using Application.Features.RegisterAudits.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.RegisterAudits.Constants.RegisterAuditsOperationClaims;

namespace Application.Features.RegisterAudits.Queries.GetById;

public class GetByIdRegisterAuditQuery : IRequest<GetByIdRegisterAuditResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdRegisterAuditQueryHandler : IRequestHandler<GetByIdRegisterAuditQuery, GetByIdRegisterAuditResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRegisterAuditRepository _registerAuditRepository;
        private readonly RegisterAuditBusinessRules _registerAuditBusinessRules;

        public GetByIdRegisterAuditQueryHandler(IMapper mapper, IRegisterAuditRepository registerAuditRepository, RegisterAuditBusinessRules registerAuditBusinessRules)
        {
            _mapper = mapper;
            _registerAuditRepository = registerAuditRepository;
            _registerAuditBusinessRules = registerAuditBusinessRules;
        }

        public async Task<GetByIdRegisterAuditResponse> Handle(GetByIdRegisterAuditQuery request, CancellationToken cancellationToken)
        {
            RegisterAudit? registerAudit = await _registerAuditRepository.GetAsync(predicate: ra => ra.Id == request.Id, cancellationToken: cancellationToken);
            await _registerAuditBusinessRules.RegisterAuditShouldExistWhenSelected(registerAudit);

            GetByIdRegisterAuditResponse response = _mapper.Map<GetByIdRegisterAuditResponse>(registerAudit);
            return response;
        }
    }
}