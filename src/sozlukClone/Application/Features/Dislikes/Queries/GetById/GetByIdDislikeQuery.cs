using Application.Features.Dislikes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Dislikes.Queries.GetById;

public class GetByIdDislikeQuery : IRequest<GetByIdDislikeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdDislikeQueryHandler : IRequestHandler<GetByIdDislikeQuery, GetByIdDislikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDislikeRepository _dislikeRepository;
        private readonly DislikeBusinessRules _dislikeBusinessRules;

        public GetByIdDislikeQueryHandler(IMapper mapper, IDislikeRepository dislikeRepository, DislikeBusinessRules dislikeBusinessRules)
        {
            _mapper = mapper;
            _dislikeRepository = dislikeRepository;
            _dislikeBusinessRules = dislikeBusinessRules;
        }

        public async Task<GetByIdDislikeResponse> Handle(GetByIdDislikeQuery request, CancellationToken cancellationToken)
        {
            Dislike? dislike = await _dislikeRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);

            await _dislikeBusinessRules.DislikeShouldExistWhenSelected(dislike);

            GetByIdDislikeResponse response = _mapper.Map<GetByIdDislikeResponse>(dislike);
            return response;
        }
    }
}