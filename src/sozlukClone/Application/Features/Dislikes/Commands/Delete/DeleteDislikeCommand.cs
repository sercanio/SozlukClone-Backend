using Application.Features.Dislikes.Constants;
using Application.Features.Dislikes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Dislikes.Commands.Delete;

public class DeleteDislikeCommand : IRequest<DeletedDislikeResponse>
{
    public Guid Id { get; set; }

    public class DeleteDislikeCommandHandler : IRequestHandler<DeleteDislikeCommand, DeletedDislikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDislikeRepository _dislikeRepository;
        private readonly DislikeBusinessRules _dislikeBusinessRules;

        public DeleteDislikeCommandHandler(IMapper mapper, IDislikeRepository dislikeRepository,
                                         DislikeBusinessRules dislikeBusinessRules)
        {
            _mapper = mapper;
            _dislikeRepository = dislikeRepository;
            _dislikeBusinessRules = dislikeBusinessRules;
        }

        public async Task<DeletedDislikeResponse> Handle(DeleteDislikeCommand request, CancellationToken cancellationToken)
        {
            Dislike? dislike = await _dislikeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _dislikeBusinessRules.DislikeShouldExistWhenSelected(dislike);

            await _dislikeRepository.DeleteAsync(dislike!);

            DeletedDislikeResponse response = _mapper.Map<DeletedDislikeResponse>(dislike);
            return response;
        }
    }
}