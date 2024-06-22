using Application.Features.TitleModOperations.Constants;
using Application.Features.TitleModOperations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.TitleModOperations.Constants.TitleModOperationsOperationClaims;

namespace Application.Features.TitleModOperations.Queries.GetById;

public class GetByIdTitleModOperationQuery : IRequest<GetByIdTitleModOperationResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdTitleModOperationQueryHandler : IRequestHandler<GetByIdTitleModOperationQuery, GetByIdTitleModOperationResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleModOperationRepository _titleModOperationRepository;
        private readonly TitleModOperationBusinessRules _titleModOperationBusinessRules;

        public GetByIdTitleModOperationQueryHandler(IMapper mapper, ITitleModOperationRepository titleModOperationRepository, TitleModOperationBusinessRules titleModOperationBusinessRules)
        {
            _mapper = mapper;
            _titleModOperationRepository = titleModOperationRepository;
            _titleModOperationBusinessRules = titleModOperationBusinessRules;
        }

        public async Task<GetByIdTitleModOperationResponse> Handle(GetByIdTitleModOperationQuery request, CancellationToken cancellationToken)
        {
            TitleModOperation? titleModOperation = await _titleModOperationRepository.GetAsync(predicate: tmo => tmo.Id == request.Id, cancellationToken: cancellationToken);
            await _titleModOperationBusinessRules.TitleModOperationShouldExistWhenSelected(titleModOperation);

            GetByIdTitleModOperationResponse response = _mapper.Map<GetByIdTitleModOperationResponse>(titleModOperation);
            return response;
        }
    }
}