using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Commands.Update;

public class UpdateLikeCommand : IRequest<UpdatedLikeResponse>
{
    public Guid Id { get; set; }
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
            Like? like = await _likeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _likeBusinessRules.LikeShouldExistWhenSelected(like);
            like = _mapper.Map(request, like);

            await _likeRepository.UpdateAsync(like!);

            UpdatedLikeResponse response = _mapper.Map<UpdatedLikeResponse>(like);
            return response;
        }
    }
}