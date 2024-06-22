using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AuthorFollowings.Queries.GetById;

public class GetByIdAuthorFollowingQuery : IRequest<GetByIdAuthorFollowingResponse>
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }

    public class GetByIdAuthorFollowingQueryHandler : IRequestHandler<GetByIdAuthorFollowingQuery, GetByIdAuthorFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorFollowingRepository _authorFollowingRepository;
        private readonly AuthorFollowingBusinessRules _authorFollowingBusinessRules;

        public GetByIdAuthorFollowingQueryHandler(IMapper mapper, IAuthorFollowingRepository authorFollowingRepository, AuthorFollowingBusinessRules authorFollowingBusinessRules)
        {
            _mapper = mapper;
            _authorFollowingRepository = authorFollowingRepository;
            _authorFollowingBusinessRules = authorFollowingBusinessRules;
        }

        public async Task<GetByIdAuthorFollowingResponse> Handle(GetByIdAuthorFollowingQuery request, CancellationToken cancellationToken)
        {
            AuthorFollowing? authorFollowing = await _authorFollowingRepository.GetAsync(
                    predicate: af => af.FollowingId == request.FollowingId && af.FollowerId == request.FollowerId,
                    cancellationToken: cancellationToken);

            await _authorFollowingBusinessRules.AuthorFollowingShouldExistWhenSelected(authorFollowing);

            GetByIdAuthorFollowingResponse response = _mapper.Map<GetByIdAuthorFollowingResponse>(authorFollowing);
            return response;
        }
    }
}