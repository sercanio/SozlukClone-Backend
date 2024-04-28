using Application.Features.PenaltyTypes.Constants;
using Application.Features.PenaltyTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.PenaltyTypes.Constants.PenaltyTypesOperationClaims;

namespace Application.Features.PenaltyTypes.Commands.Create;

public class CreatePenaltyTypeCommand : IRequest<CreatedPenaltyTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public string[] Roles => [Admin, Write, PenaltyTypesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPenaltyTypes"];

    public class CreatePenaltyTypeCommandHandler : IRequestHandler<CreatePenaltyTypeCommand, CreatedPenaltyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyTypeRepository _penaltyTypeRepository;
        private readonly PenaltyTypeBusinessRules _penaltyTypeBusinessRules;

        public CreatePenaltyTypeCommandHandler(IMapper mapper, IPenaltyTypeRepository penaltyTypeRepository,
                                         PenaltyTypeBusinessRules penaltyTypeBusinessRules)
        {
            _mapper = mapper;
            _penaltyTypeRepository = penaltyTypeRepository;
            _penaltyTypeBusinessRules = penaltyTypeBusinessRules;
        }

        public async Task<CreatedPenaltyTypeResponse> Handle(CreatePenaltyTypeCommand request, CancellationToken cancellationToken)
        {
            PenaltyType penaltyType = _mapper.Map<PenaltyType>(request);

            await _penaltyTypeRepository.AddAsync(penaltyType);

            CreatedPenaltyTypeResponse response = _mapper.Map<CreatedPenaltyTypeResponse>(penaltyType);
            return response;
        }
    }
}