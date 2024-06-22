using Application.Features.EntryModOperations.Constants;
using Application.Features.EntryModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.EntryModOperations.Constants.EntryModOperationsOperationClaims;

namespace Application.Features.EntryModOperations.Queries.GetById;

public class GetByIdEntryModOperationQuery : IRequest<GetByIdEntryModOperationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdEntryModOperationQueryHandler : IRequestHandler<GetByIdEntryModOperationQuery, GetByIdEntryModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEntryModOperationRepository _entryModOperationRepository;
        private readonly EntryModOperationBusinessRules _entryModOperationBusinessRules;

        public GetByIdEntryModOperationQueryHandler(IMapper mapper, IEntryModOperationRepository entryModOperationRepository, EntryModOperationBusinessRules entryModOperationBusinessRules)
        {
            _mapper = mapper;
            _entryModOperationRepository = entryModOperationRepository;
            _entryModOperationBusinessRules = entryModOperationBusinessRules;
        }

        public async Task<GetByIdEntryModOperationResponse> Handle(GetByIdEntryModOperationQuery request, CancellationToken cancellationToken)
        {
            EntryModOperation? entryModOperation = await _entryModOperationRepository.GetAsync(predicate: emo => emo.Id == request.Id, cancellationToken: cancellationToken);
            await _entryModOperationBusinessRules.EntryModOperationShouldExistWhenSelected(entryModOperation);

            GetByIdEntryModOperationResponse response = _mapper.Map<GetByIdEntryModOperationResponse>(entryModOperation);
            return response;
        }
    }
}