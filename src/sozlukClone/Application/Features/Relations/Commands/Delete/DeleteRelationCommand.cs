using Application.Features.Relations.Constants;
using Application.Features.Relations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Relations.Commands.Delete;

public class DeleteRelationCommand : IRequest<DeletedRelationResponse>
{
    public Guid Id { get; set; }

    public class DeleteRelationCommandHandler : IRequestHandler<DeleteRelationCommand, DeletedRelationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRelationRepository _relationRepository;
        private readonly RelationBusinessRules _relationBusinessRules;

        public DeleteRelationCommandHandler(IMapper mapper, IRelationRepository relationRepository,
                                         RelationBusinessRules relationBusinessRules)
        {
            _mapper = mapper;
            _relationRepository = relationRepository;
            _relationBusinessRules = relationBusinessRules;
        }

        public async Task<DeletedRelationResponse> Handle(DeleteRelationCommand request, CancellationToken cancellationToken)
        {
            Relation? relation = await _relationRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _relationBusinessRules.RelationShouldExistWhenSelected(relation);

            await _relationRepository.DeleteAsync(relation!);

            DeletedRelationResponse response = _mapper.Map<DeletedRelationResponse>(relation);
            return response;
        }
    }
}