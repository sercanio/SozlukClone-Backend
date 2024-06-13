using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using static Application.Features.Entries.Constants.EntriesOperationClaims;

namespace Application.Features.Entries.Queries.GetById;

public class GetByIdEntryQuery : IRequest<GetByIdEntryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdEntryQueryHandler : IRequestHandler<GetByIdEntryQuery, GetByIdEntryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryRepository _entryRepository;
        private readonly EntryBusinessRules _entryBusinessRules;

        public GetByIdEntryQueryHandler(IMapper mapper, IEntryRepository entryRepository, EntryBusinessRules entryBusinessRules)
        {
            _mapper = mapper;
            _entryRepository = entryRepository;
            _entryBusinessRules = entryBusinessRules;
        }

        public async Task<GetByIdEntryResponse> Handle(GetByIdEntryQuery request, CancellationToken cancellationToken)
        {
            Entry? entry = await _entryRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _entryBusinessRules.EntryShouldExistWhenSelected(entry);

            GetByIdEntryResponse response = _mapper.Map<GetByIdEntryResponse>(entry);
            return response;
        }
    }
}