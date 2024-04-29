using Application.Features.Entries.Constants;
using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Entries.Constants.EntriesOperationClaims;

namespace Application.Features.Entries.Commands.Create;

public class CreateEntryCommand : IRequest<CreatedEntryResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Content { get; set; }
    public required uint AuthorId { get; set; }
    public required uint TitleId { get; set; }

    public string[] Roles => [Admin, Write, EntriesOperationClaims.Create];

    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, CreatedEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public CreateEntryCommandHandler(IMapper mapper, IEntryRepository entryRepository,
                                         EntryBusinessRules entryBusinessRules)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<CreatedEntryResponse> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            Entry entry = _mapper.Map<Entry>(request);

            await _entryRepository.AddAsync(entry);

            CreatedEntryResponse response = _mapper.Map<CreatedEntryResponse>(entry);
            return response;
        }
    }
}