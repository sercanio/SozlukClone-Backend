using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Commands.Delete;

public class DeleteLikeCommand : IRequest<DeletedLikeResponse>
{
    public Guid Id { get; set; }

    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, DeletedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public DeleteLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<DeletedLikeResponse> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            await _likeBusinessRules.LikeIdShouldExistWhenSelected(request.Id, cancellationToken);

            Like? like = await _likeRepository.GetAsync(
                predicate: l => l.Id == request.Id,
                cancellationToken: cancellationToken);

            await _likeRepository.DeleteAsync(like!);

            DeletedLikeResponse response = _mapper.Map<DeletedLikeResponse>(like);
            return response;
        }
    }
}