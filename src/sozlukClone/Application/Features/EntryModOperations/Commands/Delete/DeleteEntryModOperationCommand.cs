using Application.Features.EntryModOperations.Constants;
using Application.Features.EntryModOperations.Constants;
using Application.Features.EntryModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.EntryModOperations.Constants.EntryModOperationsOperationClaims;

namespace Application.Features.EntryModOperations.Commands.Delete;

public class DeleteEntryModOperationCommand : IRequest<DeletedEntryModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, EntryModOperationsOperationClaims.Delete];

    public class DeleteEntryModOperationCommandHandler : IRequestHandler<DeleteEntryModOperationCommand, DeletedEntryModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryModOperationRepository _entryModOperationRepository;
        private readonly EntryModOperationBusinessRules _entryModOperationBusinessRules;

        public DeleteEntryModOperationCommandHandler(IMapper mapper, IEntryModOperationRepository entryModOperationRepository,
                                         EntryModOperationBusinessRules entryModOperationBusinessRules)
        {
            _mapper = mapper;
            _entryModOperationRepository = entryModOperationRepository;
            _entryModOperationBusinessRules = entryModOperationBusinessRules;
        }

        public async Task<DeletedEntryModOperationResponse> Handle(DeleteEntryModOperationCommand request, CancellationToken cancellationToken)
        {
            EntryModOperation? entryModOperation = await _entryModOperationRepository.GetAsync(predicate: emo => emo.Id == request.Id, cancellationToken: cancellationToken);
            await _entryModOperationBusinessRules.EntryModOperationShouldExistWhenSelected(entryModOperation);

            await _entryModOperationRepository.DeleteAsync(entryModOperation!);

            DeletedEntryModOperationResponse response = _mapper.Map<DeletedEntryModOperationResponse>(entryModOperation);
            return response;
        }
    }
}