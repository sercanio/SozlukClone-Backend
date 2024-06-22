using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.AuthorFollowings.Queries.GetList;

public class GetListAuthorFollowingQuery : IRequest<GetListResponse<GetListAuthorFollowingListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAuthorFollowingQueryHandler : IRequestHandler<GetListAuthorFollowingQuery, GetListResponse<GetListAuthorFollowingListItemDto>>
    {
        private readonly IAuthorFollowingRepository _authorFollowingRepository;
        private readonly IMapper _mapper;

        public GetListAuthorFollowingQueryHandler(IAuthorFollowingRepository authorFollowingRepository, IMapper mapper)
        {
            _authorFollowingRepository = authorFollowingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorFollowingListItemDto>> Handle(GetListAuthorFollowingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorFollowing> authorFollowings = await _authorFollowingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorFollowingListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorFollowingListItemDto>>(authorFollowings);
            return response;
        }
    }
}