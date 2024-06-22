using Application.Features.TitleModOperations.Constants;
using Application.Features.TitleModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.TitleModOperations.Constants.TitleModOperationsOperationClaims;

namespace Application.Features.TitleModOperations.Commands.Create;

public class CreateTitleModOperationCommand : IRequest<CreatedTitleModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public string Name { get; set; }
    public int TitleId { get; set; }
    public int IssuerId { get; set; }

    public string[] Roles => [Admin, Write, TitleModOperationsOperationClaims.Create];

    public class CreateTitleModOperationCommandHandler : IRequestHandler<CreateTitleModOperationCommand, CreatedTitleModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleModOperationRepository _titleModOperationRepository;
        private readonly TitleModOperationBusinessRules _titleModOperationBusinessRules;

        public CreateTitleModOperationCommandHandler(IMapper mapper, ITitleModOperationRepository titleModOperationRepository,
                                         TitleModOperationBusinessRules titleModOperationBusinessRules)
        {
            _mapper = mapper;
            _titleModOperationRepository = titleModOperationRepository;
            _titleModOperationBusinessRules = titleModOperationBusinessRules;
        }

        public async Task<CreatedTitleModOperationResponse> Handle(CreateTitleModOperationCommand request, CancellationToken cancellationToken)
        {
            TitleModOperation titleModOperation = _mapper.Map<TitleModOperation>(request);

            await _titleModOperationRepository.AddAsync(titleModOperation);

            CreatedTitleModOperationResponse response = _mapper.Map<CreatedTitleModOperationResponse>(titleModOperation);
            return response;
        }
    }
}