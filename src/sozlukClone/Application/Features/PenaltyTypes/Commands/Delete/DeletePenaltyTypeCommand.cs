using Application.Features.PenaltyTypes.Constants;
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

namespace Application.Features.PenaltyTypes.Commands.Delete;

public class DeletePenaltyTypeCommand : IRequest<DeletedPenaltyTypeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Write, PenaltyTypesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetPenaltyTypes"];

    public class DeletePenaltyTypeCommandHandler : IRequestHandler<DeletePenaltyTypeCommand, DeletedPenaltyTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyTypeRepository _penaltyTypeRepository;
        private readonly PenaltyTypeBusinessRules _penaltyTypeBusinessRules;

        public DeletePenaltyTypeCommandHandler(IMapper mapper, IPenaltyTypeRepository penaltyTypeRepository,
                                         PenaltyTypeBusinessRules penaltyTypeBusinessRules)
        {
            _mapper = mapper;
            _penaltyTypeRepository = penaltyTypeRepository;
            _penaltyTypeBusinessRules = penaltyTypeBusinessRules;
        }

        public async Task<DeletedPenaltyTypeResponse> Handle(DeletePenaltyTypeCommand request, CancellationToken cancellationToken)
        {
            PenaltyType? penaltyType = await _penaltyTypeRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _penaltyTypeBusinessRules.PenaltyTypeShouldExistWhenSelected(penaltyType);

            await _penaltyTypeRepository.DeleteAsync(penaltyType!);

            DeletedPenaltyTypeResponse response = _mapper.Map<DeletedPenaltyTypeResponse>(penaltyType);
            return response;
        }
    }
}