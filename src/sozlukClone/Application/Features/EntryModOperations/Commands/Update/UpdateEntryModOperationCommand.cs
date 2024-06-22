using Application.Features.EntryModOperations.Constants;
using Application.Features.EntryModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.EntryModOperations.Constants.EntryModOperationsOperationClaims;

namespace Application.Features.EntryModOperations.Commands.Update;

public class UpdateEntryModOperationCommand : IRequest<UpdatedEntryModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int EntryId { get; set; }
    public required Guid ModOperationId { get; set; }

    public string[] Roles => [Admin, Write, EntryModOperationsOperationClaims.Update];

    public class UpdateEntryModOperationCommandHandler : IRequestHandler<UpdateEntryModOperationCommand, UpdatedEntryModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryModOperationRepository _entryModOperationRepository;
        private readonly EntryModOperationBusinessRules _entryModOperationBusinessRules;

        public UpdateEntryModOperationCommandHandler(IMapper mapper, IEntryModOperationRepository entryModOperationRepository,
                                         EntryModOperationBusinessRules entryModOperationBusinessRules)
        {
            _mapper = mapper;
            _entryModOperationRepository = entryModOperationRepository;
            _entryModOperationBusinessRules = entryModOperationBusinessRules;
        }

        public async Task<UpdatedEntryModOperationResponse> Handle(UpdateEntryModOperationCommand request, CancellationToken cancellationToken)
        {
            EntryModOperation? entryModOperation = await _entryModOperationRepository.GetAsync(predicate: emo => emo.Id == request.Id, cancellationToken: cancellationToken);
            await _entryModOperationBusinessRules.EntryModOperationShouldExistWhenSelected(entryModOperation);
            entryModOperation = _mapper.Map(request, entryModOperation);

            await _entryModOperationRepository.UpdateAsync(entryModOperation!);

            UpdatedEntryModOperationResponse response = _mapper.Map<UpdatedEntryModOperationResponse>(entryModOperation);
            return response;
        }
    }
}