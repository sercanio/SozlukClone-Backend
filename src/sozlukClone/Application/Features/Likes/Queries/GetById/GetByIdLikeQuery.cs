using Application.Features.Likes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Likes.Queries.GetById;

public class GetByIdLikeQuery : IRequest<GetByIdLikeResponse>
{
    public Guid Id { get; set; }

    public class GetByIdLikeQueryHandler : IRequestHandler<GetByIdLikeQuery, GetByIdLikeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILikeRepository _likeRepository;
        private readonly LikeBusinessRules _likeBusinessRules;

        public GetByIdLikeQueryHandler(IMapper mapper, ILikeRepository likeRepository, LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeRepository = likeRepository;
            _likeBusinessRules = likeBusinessRules;
        }

        public async Task<GetByIdLikeResponse> Handle(GetByIdLikeQuery request, CancellationToken cancellationToken)
        {
            Like? like = await _likeRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            await _likeBusinessRules.LikeShouldExistWhenSelected(like);

            GetByIdLikeResponse response = _mapper.Map<GetByIdLikeResponse>(like);
            return response;
        }
    }
}