using Application.Features.AuthorModOperations.Constants;
using Application.Features.AuthorModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AuthorModOperations.Constants.AuthorModOperationsOperationClaims;

namespace Application.Features.AuthorModOperations.Queries.GetById;

public class GetByIdAuthorModOperationQuery : IRequest<GetByIdAuthorModOperationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAuthorModOperationQueryHandler : IRequestHandler<GetByIdAuthorModOperationQuery, GetByIdAuthorModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorModOperationRepository _authorModOperationRepository;
        private readonly AuthorModOperationBusinessRules _authorModOperationBusinessRules;

        public GetByIdAuthorModOperationQueryHandler(IMapper mapper, IAuthorModOperationRepository authorModOperationRepository, AuthorModOperationBusinessRules authorModOperationBusinessRules)
        {
            _mapper = mapper;
            _authorModOperationRepository = authorModOperationRepository;
            _authorModOperationBusinessRules = authorModOperationBusinessRules;
        }

        public async Task<GetByIdAuthorModOperationResponse> Handle(GetByIdAuthorModOperationQuery request, CancellationToken cancellationToken)
        {
            AuthorModOperation? authorModOperation = await _authorModOperationRepository.GetAsync(predicate: amo => amo.Id == request.Id, cancellationToken: cancellationToken);
            await _authorModOperationBusinessRules.AuthorModOperationShouldExistWhenSelected(authorModOperation);

            GetByIdAuthorModOperationResponse response = _mapper.Map<GetByIdAuthorModOperationResponse>(authorModOperation);
            return response;
        }
    }
}