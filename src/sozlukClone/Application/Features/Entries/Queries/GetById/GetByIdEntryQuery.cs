using Application.Features.Entries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Entries.Queries.GetById;

public class GetByIdEntryQuery : IRequest<GetByIdEntryResponse>
{
    public int Id { get; set; }

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
            Entry? entry = await _entryRepository.GetAsync(predicate: e => e.Id == request.Id, include: e => e.Include(e => e.Title).Include(e => e.Author), cancellationToken: cancellationToken);
            await _entryBusinessRules.EntryShouldExistWhenSelected(entry);

            GetByIdEntryResponse response = _mapper.Map<GetByIdEntryResponse>(entry);
            return response;
        }
    }
}