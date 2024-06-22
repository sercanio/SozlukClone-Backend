using Application.Features.AuthorModOperations.Constants;
using Application.Features.AuthorModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.AuthorModOperations.Constants.AuthorModOperationsOperationClaims;

namespace Application.Features.AuthorModOperations.Commands.Create;

public class CreateAuthorModOperationCommand : IRequest<CreatedAuthorModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public required int AuthorId { get; set; }
    public required Guid ModOperationId { get; set; }
    public Guid? PenaltyId { get; set; }

    public string[] Roles => [Admin, Write, AuthorModOperationsOperationClaims.Create];

    public class CreateAuthorModOperationCommandHandler : IRequestHandler<CreateAuthorModOperationCommand, CreatedAuthorModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorModOperationRepository _authorModOperationRepository;
        private readonly AuthorModOperationBusinessRules _authorModOperationBusinessRules;

        public CreateAuthorModOperationCommandHandler(IMapper mapper, IAuthorModOperationRepository authorModOperationRepository,
                                         AuthorModOperationBusinessRules authorModOperationBusinessRules)
        {
            _mapper = mapper;
            _authorModOperationRepository = authorModOperationRepository;
            _authorModOperationBusinessRules = authorModOperationBusinessRules;
        }

        public async Task<CreatedAuthorModOperationResponse> Handle(CreateAuthorModOperationCommand request, CancellationToken cancellationToken)
        {
            AuthorModOperation authorModOperation = _mapper.Map<AuthorModOperation>(request);

            await _authorModOperationRepository.AddAsync(authorModOperation);

            CreatedAuthorModOperationResponse response = _mapper.Map<CreatedAuthorModOperationResponse>(authorModOperation);
            return response;
        }
    }
}