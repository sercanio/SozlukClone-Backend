using Application.Features.Penalties.Constants;
using Application.Features.Penalties.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Penalties.Constants.PenaltiesOperationClaims;

namespace Application.Features.Penalties.Commands.Create;

public class CreatePenaltyCommand : IRequest<CreatedPenaltyResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Reason { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required byte PenaltyTypeId { get; set; }
    public required uint AuthorId { get; set; }
    public required uint IssuerId { get; set; }

    public string[] Roles => [Admin, Write, PenaltiesOperationClaims.Create];

    public class CreatePenaltyCommandHandler : IRequestHandler<CreatePenaltyCommand, CreatedPenaltyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPenaltyRepository _penaltyRepository;
        private readonly PenaltyBusinessRules _penaltyBusinessRules;

        public CreatePenaltyCommandHandler(IMapper mapper, IPenaltyRepository penaltyRepository,
                                         PenaltyBusinessRules penaltyBusinessRules)
        {
            _mapper = mapper;
            _penaltyRepository = penaltyRepository;
            _penaltyBusinessRules = penaltyBusinessRules;
        }

        public async Task<CreatedPenaltyResponse> Handle(CreatePenaltyCommand request, CancellationToken cancellationToken)
        {
            Penalty penalty = _mapper.Map<Penalty>(request);

            await _penaltyRepository.AddAsync(penalty);

            CreatedPenaltyResponse response = _mapper.Map<CreatedPenaltyResponse>(penalty);
            return response;
        }
    }
}