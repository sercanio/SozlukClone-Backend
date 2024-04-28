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

namespace Application.Features.PenaltyTypes.Commands.Update;

public class UpdatePenaltyTypeCommand : IRequest<UpdatedPenaltyTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public string[] Roles => [Admin, Write, PenaltyTypesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPenaltyTypes"];

    public class UpdatePenaltyTypeCommandHandler : IRequestHandler<UpdatePenaltyTypeCommand, UpdatedPenaltyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyTypeRepository _penaltyTypeRepository;
        private readonly PenaltyTypeBusinessRules _penaltyTypeBusinessRules;

        public UpdatePenaltyTypeCommandHandler(IMapper mapper, IPenaltyTypeRepository penaltyTypeRepository,
                                         PenaltyTypeBusinessRules penaltyTypeBusinessRules)
        {
            _mapper = mapper;
            _penaltyTypeRepository = penaltyTypeRepository;
            _penaltyTypeBusinessRules = penaltyTypeBusinessRules;
        }

        public async Task<UpdatedPenaltyTypeResponse> Handle(UpdatePenaltyTypeCommand request, CancellationToken cancellationToken)
        {
            PenaltyType? penaltyType = await _penaltyTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _penaltyTypeBusinessRules.PenaltyTypeShouldExistWhenSelected(penaltyType);
            penaltyType = _mapper.Map(request, penaltyType);

            await _penaltyTypeRepository.UpdateAsync(penaltyType!);

            UpdatedPenaltyTypeResponse response = _mapper.Map<UpdatedPenaltyTypeResponse>(penaltyType);
            return response;
        }
    }
}