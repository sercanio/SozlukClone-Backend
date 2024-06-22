using Application.Features.EntryModOperations.Constants;
using Application.Features.EntryModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.EntryModOperations.Constants.EntryModOperationsOperationClaims;

namespace Application.Features.EntryModOperations.Commands.Create;

public class CreateEntryModOperationCommand : IRequest<CreatedEntryModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public required int EntryId { get; set; }
    public required Guid ModOperationId { get; set; }

    public string[] Roles => [Admin, Write, EntryModOperationsOperationClaims.Create];

    public class CreateEntryModOperationCommandHandler : IRequestHandler<CreateEntryModOperationCommand, CreatedEntryModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryModOperationRepository _entryModOperationRepository;
        private readonly EntryModOperationBusinessRules _entryModOperationBusinessRules;

        public CreateEntryModOperationCommandHandler(IMapper mapper, IEntryModOperationRepository entryModOperationRepository,
                                         EntryModOperationBusinessRules entryModOperationBusinessRules)
        {
            _mapper = mapper;
            _entryModOperationRepository = entryModOperationRepository;
            _entryModOperationBusinessRules = entryModOperationBusinessRules;
        }

        public async Task<CreatedEntryModOperationResponse> Handle(CreateEntryModOperationCommand request, CancellationToken cancellationToken)
        {
            EntryModOperation entryModOperation = _mapper.Map<EntryModOperation>(request);

            await _entryModOperationRepository.AddAsync(entryModOperation);

            CreatedEntryModOperationResponse response = _mapper.Map<CreatedEntryModOperationResponse>(entryModOperation);
            return response;
        }
    }
}