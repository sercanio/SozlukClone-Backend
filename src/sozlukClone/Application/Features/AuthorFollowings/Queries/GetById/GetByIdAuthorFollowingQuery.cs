using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AuthorFollowings.Queries.GetById;

public class GetByIdAuthorFollowingQuery : IRequest<GetByIdAuthorFollowingResponse>
{
    public Guid Id { get; set; }
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
            AuthorFollowing? following = await _authorFollowingRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);

            await _authorFollowingBusinessRules.AuthorFollowingShouldExistWhenSelected(following);

            GetByIdAuthorFollowingResponse response = _mapper.Map<GetByIdAuthorFollowingResponse>(following);
            return response;
        }
    }
}