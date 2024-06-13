using Application.Features.Entries.Constants;
using Application.Features.Entries.Constants;
using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Entries.Constants.EntriesOperationClaims;

namespace Application.Features.Entries.Commands.Delete;

public class DeleteEntryCommand : IRequest<DeletedEntryResponse>, ISecuredRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, EntriesOperationClaims.Delete];

    public class DeleteEntryCommandHandler : IRequestHandler<DeleteEntryCommand, DeletedEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public DeleteEntryCommandHandler(IMapper mapper, IEntryRepository entryRepository,
                                         EntryBusinessRules entryBusinessRules)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<DeletedEntryResponse> Handle(DeleteEntryCommand request, CancellationToken cancellationToken)
        {
            Entry? entry = await _entryRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _entryBusinessRules.EntryShouldExistWhenSelected(entry);

            await _entryRepository.DeleteAsync(entry!);

            DeletedEntryResponse response = _mapper.Map<DeletedEntryResponse>(entry);
            return response;
        }
    }
}