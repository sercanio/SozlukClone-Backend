using Application.Features.AuthorModOperations.Constants;
using Application.Features.AuthorModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.AuthorModOperations.Constants.AuthorModOperationsOperationClaims;

namespace Application.Features.AuthorModOperations.Commands.Update;

public class UpdateAuthorModOperationCommand : IRequest<UpdatedAuthorModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int AuthorId { get; set; }
    public required Guid ModOperationId { get; set; }
    public Guid? PenaltyId { get; set; }

    public string[] Roles => [Admin, Write, AuthorModOperationsOperationClaims.Update];

    public class UpdateAuthorModOperationCommandHandler : IRequestHandler<UpdateAuthorModOperationCommand, UpdatedAuthorModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorModOperationRepository _authorModOperationRepository;
        private readonly AuthorModOperationBusinessRules _authorModOperationBusinessRules;

        public UpdateAuthorModOperationCommandHandler(IMapper mapper, IAuthorModOperationRepository authorModOperationRepository,
                                         AuthorModOperationBusinessRules authorModOperationBusinessRules)
        {
            _mapper = mapper;
            _authorModOperationRepository = authorModOperationRepository;
            _authorModOperationBusinessRules = authorModOperationBusinessRules;
        }

        public async Task<UpdatedAuthorModOperationResponse> Handle(UpdateAuthorModOperationCommand request, CancellationToken cancellationToken)
        {
            AuthorModOperation? authorModOperation = await _authorModOperationRepository.GetAsync(predicate: amo => amo.Id == request.Id, cancellationToken: cancellationToken);
            await _authorModOperationBusinessRules.AuthorModOperationShouldExistWhenSelected(authorModOperation);
            authorModOperation = _mapper.Map(request, authorModOperation);

            await _authorModOperationRepository.UpdateAsync(authorModOperation!);

            UpdatedAuthorModOperationResponse response = _mapper.Map<UpdatedAuthorModOperationResponse>(authorModOperation);
            return response;
        }
    }
}