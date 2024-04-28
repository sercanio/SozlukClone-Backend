using Application.Features.PenaltyTypes.Constants;
using Application.Features.PenaltyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.PenaltyTypes.Constants.PenaltyTypesOperationClaims;

namespace Application.Features.PenaltyTypes.Queries.GetById;

public class GetByIdPenaltyTypeQuery : IRequest<GetByIdPenaltyTypeResponse>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdPenaltyTypeQueryHandler : IRequestHandler<GetByIdPenaltyTypeQuery, GetByIdPenaltyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyTypeRepository _penaltyTypeRepository;
        private readonly PenaltyTypeBusinessRules _penaltyTypeBusinessRules;

        public GetByIdPenaltyTypeQueryHandler(IMapper mapper, IPenaltyTypeRepository penaltyTypeRepository, PenaltyTypeBusinessRules penaltyTypeBusinessRules)
        {
            _mapper = mapper;
            _penaltyTypeRepository = penaltyTypeRepository;
            _penaltyTypeBusinessRules = penaltyTypeBusinessRules;
        }

        public async Task<GetByIdPenaltyTypeResponse> Handle(GetByIdPenaltyTypeQuery request, CancellationToken cancellationToken)
        {
            PenaltyType? penaltyType = await _penaltyTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _penaltyTypeBusinessRules.PenaltyTypeShouldExistWhenSelected(penaltyType);

            GetByIdPenaltyTypeResponse response = _mapper.Map<GetByIdPenaltyTypeResponse>(penaltyType);
            return response;
        }
    }
}