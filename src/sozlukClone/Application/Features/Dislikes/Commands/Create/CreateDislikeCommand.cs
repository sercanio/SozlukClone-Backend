using Application.Features.Dislikes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Dislikes.Commands.Create;

public class CreateDislikeCommand : IRequest<CreatedDislikeResponse>
{
    public required int EntryId { get; set; }
    public required int AuthorId { get; set; }

    public class CreateDislikeCommandHandler : IRequestHandler<CreateDislikeCommand, CreatedDislikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDislikeRepository _dislikeRepository;
        private readonly DislikeBusinessRules _dislikeBusinessRules;

        public CreateDislikeCommandHandler(IMapper mapper, IDislikeRepository dislikeRepository,
                                         DislikeBusinessRules dislikeBusinessRules)
        {
            _mapper = mapper;
            _dislikeRepository = dislikeRepository;
            _dislikeBusinessRules = dislikeBusinessRules;
        }

        public async Task<CreatedDislikeResponse> Handle(CreateDislikeCommand request, CancellationToken cancellationToken)
        {

            Dislike dislike = _mapper.Map<Dislike>(request);

            await _dislikeBusinessRules.DisikeShouldNotOwnedByEntryAuthorWhenSelected(dislike, cancellationToken);
            await _dislikeBusinessRules.DisikeShouldNotDuplicatedWhenInserted(dislike, cancellationToken);
            await _dislikeBusinessRules.LikeShouldNotExistWhenDislikeInserted(dislike, cancellationToken);
            await _dislikeBusinessRules.FavoriteShouldNotExistWhenDislikeInserted(dislike, cancellationToken);

            await _dislikeRepository.AddAsync(dislike);

            CreatedDislikeResponse response = _mapper.Map<CreatedDislikeResponse>(dislike);
            return response;
        }
    }
}