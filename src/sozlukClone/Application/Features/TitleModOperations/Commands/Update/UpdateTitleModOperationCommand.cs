using Application.Features.TitleModOperations.Constants;
using Application.Features.TitleModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.TitleModOperations.Constants.TitleModOperationsOperationClaims;

namespace Application.Features.TitleModOperations.Commands.Update;

public class UpdateTitleModOperationCommand : IRequest<UpdatedTitleModOperationResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int TitleId { get; set; }
    public required Guid ModOperationId { get; set; }

    public string[] Roles => [Admin, Write, TitleModOperationsOperationClaims.Update];

    public class UpdateTitleModOperationCommandHandler : IRequestHandler<UpdateTitleModOperationCommand, UpdatedTitleModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleModOperationRepository _titleModOperationRepository;
        private readonly TitleModOperationBusinessRules _titleModOperationBusinessRules;

        public UpdateTitleModOperationCommandHandler(IMapper mapper, ITitleModOperationRepository titleModOperationRepository,
                                         TitleModOperationBusinessRules titleModOperationBusinessRules)
        {
            _mapper = mapper;
            _titleModOperationRepository = titleModOperationRepository;
            _titleModOperationBusinessRules = titleModOperationBusinessRules;
        }

        public async Task<UpdatedTitleModOperationResponse> Handle(UpdateTitleModOperationCommand request, CancellationToken cancellationToken)
        {
            TitleModOperation? titleModOperation = await _titleModOperationRepository.GetAsync(predicate: tmo => tmo.Id == request.Id, cancellationToken: cancellationToken);
            await _titleModOperationBusinessRules.TitleModOperationShouldExistWhenSelected(titleModOperation);
            titleModOperation = _mapper.Map(request, titleModOperation);

            await _titleModOperationRepository.UpdateAsync(titleModOperation!);

            UpdatedTitleModOperationResponse response = _mapper.Map<UpdatedTitleModOperationResponse>(titleModOperation);
            return response;
        }
    }
}