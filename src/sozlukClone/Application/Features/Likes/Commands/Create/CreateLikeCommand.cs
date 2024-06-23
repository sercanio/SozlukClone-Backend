using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Commands.Create;

public class CreateLikeCommand : IRequest<CreatedLikeResponse>
{
    public required int EntryId { get; set; }
    public required int AuthorId { get; set; }

    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommand, CreatedLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public CreateLikeCommandHandler(IMapper mapper, ILikeRepository likeRepository,
                                         LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<CreatedLikeResponse> Handle(CreateLikeCommand request, CancellationToken cancellationToken)
        {
            Like like = _mapper.Map<Like>(request);

            await _likeBusinessRules.LikeShouldNotOwnedByEntryAuthorWhenSelected(like, cancellationToken);
            await _likeBusinessRules.LikeShouldNotDuplicatedWhenInserted(like);
            await _likeBusinessRules.DislikeShouldNotExistWhenLikeInserted(like);

            await _likeRepository.AddAsync(like, cancellationToken);

            CreatedLikeResponse response = _mapper.Map<CreatedLikeResponse>(like);
            return response;
        }
    }
}