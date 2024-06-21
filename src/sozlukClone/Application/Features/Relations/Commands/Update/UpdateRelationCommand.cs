using Application.Features.Relations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Relations.Commands.Update;

public class UpdateRelationCommand : IRequest<UpdatedRelationResponse>
{
    public Guid Id { get; set; }
    public required int FollowerId { get; set; }
    public required int FollowingId { get; set; }

    public class UpdateRelationCommandHandler : IRequestHandler<UpdateRelationCommand, UpdatedRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRelationRepository _relationRepository;
        private readonly RelationBusinessRules _relationBusinessRules;

        public UpdateRelationCommandHandler(IMapper mapper, IRelationRepository relationRepository,
                                         RelationBusinessRules relationBusinessRules)
        {
            _mapper = mapper;
            _relationRepository = relationRepository;
            _relationBusinessRules = relationBusinessRules;
        }

        public async Task<UpdatedRelationResponse> Handle(UpdateRelationCommand request, CancellationToken cancellationToken)
        {
            Relation? relation = await _relationRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _relationBusinessRules.RelationShouldExistWhenSelected(relation);
            relation = _mapper.Map(request, relation);

            await _relationRepository.UpdateAsync(relation!);

            UpdatedRelationResponse response = _mapper.Map<UpdatedRelationResponse>(relation);
            return response;
        }
    }
}