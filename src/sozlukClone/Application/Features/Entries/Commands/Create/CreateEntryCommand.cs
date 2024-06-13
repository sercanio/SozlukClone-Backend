using Application.Features.Authors.Rules;
using Application.Features.Entries.Constants;
using Application.Features.Entries.Rules;
using Application.Features.Titles.Rules;
using Application.Services.Authors;
using Application.Services.Repositories;
using Application.Services.Titles;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Entries.Constants.EntriesOperationClaims;

namespace Application.Features.Entries.Commands.Create;

public class CreateEntryCommand : IRequest<CreatedEntryResponse>, ISecuredRequest, ITransactionalRequest
{
    public required string Content { get; set; }
    public required int AuthorId { get; set; }
    public required int TitleId { get; set; }

    public string[] Roles => [Admin, Write, EntriesOperationClaims.Create];

    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, CreatedEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly ITitleService _titleService;
        private readonly IAuthorService _authorService;
        private readonly EntryBusinessRules _entryBusinessRules;
        private readonly TitleBusinessRules _titleBusinessRules;
        private readonly AuthorBusinessRules _authorBusinessRules;

        public CreateEntryCommandHandler(IMapper mapper, IEntryRepository entryRepository,
                                         EntryBusinessRules entryBusinessRules, ITitleService titleService, TitleBusinessRules titleBusinessRules, AuthorBusinessRules authorBusinessRules, IAuthorService authorService)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _entryBusinessRules = entryBusinessRules;
            _titleService = titleService;
            _titleBusinessRules = titleBusinessRules;
            _authorBusinessRules = authorBusinessRules;
            _authorService = authorService;
        }

        public async Task<CreatedEntryResponse> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            Entry entry = _mapper.Map<Entry>(request);
            await _entryBusinessRules.EntryContentCannotBeEmpty(entry);

            await _entryRepository.AddAsync(entry);

            CreatedEntryResponse response = _mapper.Map<CreatedEntryResponse>(entry);
            return response;
        }
    }
}