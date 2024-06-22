using Application.Features.TitleFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TitleFollowings.Queries.GetById;

public class GetByIdTitleFollowingQuery : IRequest<GetByIdTitleFollowingResponse>
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }

    public class GetByIdTitleFollowingQueryHandler : IRequestHandler<GetByIdTitleFollowingQuery, GetByIdTitleFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleFollowingRepository _titleFollowingRepository;
        private readonly TitleFollowingBusinessRules _titleFollowingBusinessRules;

        public GetByIdTitleFollowingQueryHandler(IMapper mapper, ITitleFollowingRepository titleFollowingRepository, TitleFollowingBusinessRules titleFollowingBusinessRules)
        {
            _mapper = mapper;
            _titleFollowingRepository = titleFollowingRepository;
            _titleFollowingBusinessRules = titleFollowingBusinessRules;
        }

        public async Task<GetByIdTitleFollowingResponse> Handle(GetByIdTitleFollowingQuery request, CancellationToken cancellationToken)
        {
            TitleFollowing? titleFollowing = await _titleFollowingRepository.GetAsync(
                predicate: tf => tf.TitleId == request.TitleId && tf.AuthorId == request.AuthorId,
                cancellationToken: cancellationToken);

            await _titleFollowingBusinessRules.TitleFollowingShouldExistWhenSelected(titleFollowing);

            GetByIdTitleFollowingResponse response = _mapper.Map<GetByIdTitleFollowingResponse>(titleFollowing);
            return response;
        }
    }
}