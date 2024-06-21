using Application.Features.Relations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Relations.Queries.GetById;

public class GetByIdRelationQuery : IRequest<GetByIdRelationResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRelationQueryHandler : IRequestHandler<GetByIdRelationQuery, GetByIdRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRelationRepository _relationRepository;
        private readonly RelationBusinessRules _relationBusinessRules;

        public GetByIdRelationQueryHandler(IMapper mapper, IRelationRepository relationRepository, RelationBusinessRules relationBusinessRules)
        {
            _mapper = mapper;
            _relationRepository = relationRepository;
            _relationBusinessRules = relationBusinessRules;
        }

        public async Task<GetByIdRelationResponse> Handle(GetByIdRelationQuery request, CancellationToken cancellationToken)
        {
            Relation? relation = await _relationRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _relationBusinessRules.RelationShouldExistWhenSelected(relation);

            GetByIdRelationResponse response = _mapper.Map<GetByIdRelationResponse>(relation);
            return response;
        }
    }
}