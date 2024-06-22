using Application.Features.TitleModOperations.Constants;
using Application.Features.TitleModOperations.Constants;
using Application.Features.TitleModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.TitleModOperations.Constants.TitleModOperationsOperationClaims;

namespace Application.Features.TitleModOperations.Commands.Delete;

public class DeleteTitleModOperationCommand : IRequest<DeletedTitleModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, TitleModOperationsOperationClaims.Delete];

    public class DeleteTitleModOperationCommandHandler : IRequestHandler<DeleteTitleModOperationCommand, DeletedTitleModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleModOperationRepository _titleModOperationRepository;
        private readonly TitleModOperationBusinessRules _titleModOperationBusinessRules;

        public DeleteTitleModOperationCommandHandler(IMapper mapper, ITitleModOperationRepository titleModOperationRepository,
                                         TitleModOperationBusinessRules titleModOperationBusinessRules)
        {
            _mapper = mapper;
            _titleModOperationRepository = titleModOperationRepository;
            _titleModOperationBusinessRules = titleModOperationBusinessRules;
        }

        public async Task<DeletedTitleModOperationResponse> Handle(DeleteTitleModOperationCommand request, CancellationToken cancellationToken)
        {
            TitleModOperation? titleModOperation = await _titleModOperationRepository.GetAsync(predicate: tmo => tmo.Id == request.Id, cancellationToken: cancellationToken);
            await _titleModOperationBusinessRules.TitleModOperationShouldExistWhenSelected(titleModOperation);

            await _titleModOperationRepository.DeleteAsync(titleModOperation!);

            DeletedTitleModOperationResponse response = _mapper.Map<DeletedTitleModOperationResponse>(titleModOperation);
            return response;
        }
    }
}