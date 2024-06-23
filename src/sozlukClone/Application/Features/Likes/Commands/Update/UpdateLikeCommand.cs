using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommand : IRequest<UpdatedLikeResponse>
{
    public required int EntryId { get; set; }
    public required int AuthorId { get; set; }

    public class UpdateLikeCommandHandler : IRequestHandler<UpdateLikeCommand, UpdatedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public UpdateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<UpdatedLikeResponse> Handle(UpdateLikeCommand request, CancellationToken cancellationToken)
        {
            Like like = _mapper.Map<Like>(request);

            await _likeBusinessRules.LikeIdShouldExistWhenSelected(like.Id, cancellationToken);

            await _likeRepository.UpdateAsync(like!);

            UpdatedLikeResponse response = _mapper.Map<UpdatedLikeResponse>(like);
            return response;
        }
    }
}