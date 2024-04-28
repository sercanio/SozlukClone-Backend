using Application.Features.Entries.Constants;
using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Entries.Constants.EntriesOperationClaims;

namespace Application.Features.Entries.Commands.Update;

public class UpdateEntryCommand : IRequest<UpdatedEntryResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }
    public required string Content { get; set; }
    public required uint AuthorId { get; set; }
    public required uint TitleId { get; set; }

    public string[] Roles => [Admin, Write, EntriesOperationClaims.Update];

    public class UpdateEntryCommandHandler : IRequestHandler<UpdateEntryCommand, UpdatedEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public UpdateEntryCommandHandler(IMapper mapper, IEntryRepository entryRepository,
                                         EntryBusinessRules entryBusinessRules)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<UpdatedEntryResponse> Handle(UpdateEntryCommand request, CancellationToken cancellationToken)
        {
            Entry? entry = await _entryRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _entryBusinessRules.EntryShouldExistWhenSelected(entry);
            entry = _mapper.Map(request, entry);

            await _entryRepository.UpdateAsync(entry!);

            UpdatedEntryResponse response = _mapper.Map<UpdatedEntryResponse>(entry);
            return response;
        }
    }
}