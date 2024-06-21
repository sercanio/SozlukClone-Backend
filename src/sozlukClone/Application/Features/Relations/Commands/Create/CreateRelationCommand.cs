using Application.Features.Relations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Relations.Commands.Create;

public class CreateRelationCommand : IRequest<CreatedRelationResponse>
{
    public required int FollowerId { get; set; }
    public required int FollowingId { get; set; }

    public class CreateRelationCommandHandler : IRequestHandler<CreateRelationCommand, CreatedRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRelationRepository _relationRepository;
        private readonly RelationBusinessRules _relationBusinessRules;

        public CreateRelationCommandHandler(IMapper mapper, IRelationRepository relationRepository,
                                         RelationBusinessRules relationBusinessRules)
        {
            _mapper = mapper;
            _relationRepository = relationRepository;
            _relationBusinessRules = relationBusinessRules;
        }

        public async Task<CreatedRelationResponse> Handle(CreateRelationCommand request, CancellationToken cancellationToken)
        {
            Relation relation = _mapper.Map<Relation>(request);

            await _relationRepository.AddAsync(relation);

            CreatedRelationResponse response = _mapper.Map<CreatedRelationResponse>(relation);
            return response;
        }
    }
}