using Application.Features.Dislikes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Dislikes.Commands.Update;

public class UpdateDislikeCommand : IRequest<UpdatedDislikeResponse>
{
    public Guid Id { get; set; }
    public required int EntryId { get; set; }
    public required int AuthorId { get; set; }

    public class UpdateDislikeCommandHandler : IRequestHandler<UpdateDislikeCommand, UpdatedDislikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDislikeRepository _dislikeRepository;
        private readonly DislikeBusinessRules _dislikeBusinessRules;

        public UpdateDislikeCommandHandler(IMapper mapper, IDislikeRepository dislikeRepository,
                                         DislikeBusinessRules dislikeBusinessRules)
        {
            _mapper = mapper;
            _dislikeRepository = dislikeRepository;
            _dislikeBusinessRules = dislikeBusinessRules;
        }

        public async Task<UpdatedDislikeResponse> Handle(UpdateDislikeCommand request, CancellationToken cancellationToken)
        {
            Dislike? dislike = await _dislikeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _dislikeBusinessRules.DislikeShouldExistWhenSelected(dislike);
            dislike = _mapper.Map(request, dislike);

            await _dislikeRepository.UpdateAsync(dislike!);

            UpdatedDislikeResponse response = _mapper.Map<UpdatedDislikeResponse>(dislike);
            return response;
        }
    }
}