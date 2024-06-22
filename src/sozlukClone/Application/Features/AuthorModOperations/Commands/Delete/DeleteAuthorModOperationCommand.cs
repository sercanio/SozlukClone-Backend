using Application.Features.AuthorModOperations.Constants;
using Application.Features.AuthorModOperations.Constants;
using Application.Features.AuthorModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.AuthorModOperations.Constants.AuthorModOperationsOperationClaims;

namespace Application.Features.AuthorModOperations.Commands.Delete;

public class DeleteAuthorModOperationCommand : IRequest<DeletedAuthorModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AuthorModOperationsOperationClaims.Delete];

    public class DeleteAuthorModOperationCommandHandler : IRequestHandler<DeleteAuthorModOperationCommand, DeletedAuthorModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorModOperationRepository _authorModOperationRepository;
        private readonly AuthorModOperationBusinessRules _authorModOperationBusinessRules;

        public DeleteAuthorModOperationCommandHandler(IMapper mapper, IAuthorModOperationRepository authorModOperationRepository,
                                         AuthorModOperationBusinessRules authorModOperationBusinessRules)
        {
            _mapper = mapper;
            _authorModOperationRepository = authorModOperationRepository;
            _authorModOperationBusinessRules = authorModOperationBusinessRules;
        }

        public async Task<DeletedAuthorModOperationResponse> Handle(DeleteAuthorModOperationCommand request, CancellationToken cancellationToken)
        {
            AuthorModOperation? authorModOperation = await _authorModOperationRepository.GetAsync(predicate: amo => amo.Id == request.Id, cancellationToken: cancellationToken);
            await _authorModOperationBusinessRules.AuthorModOperationShouldExistWhenSelected(authorModOperation);

            await _authorModOperationRepository.DeleteAsync(authorModOperation!);

            DeletedAuthorModOperationResponse response = _mapper.Map<DeletedAuthorModOperationResponse>(authorModOperation);
            return response;
        }
    }
}