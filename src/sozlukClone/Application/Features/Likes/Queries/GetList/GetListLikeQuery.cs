using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Likes.Queries.GetList;

public class GetListLikeQuery : IRequest<GetListResponse<GetListLikeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLikeQueryHandler : IRequestHandler<GetListLikeQuery, GetListResponse<GetListLikeListItemDto>>
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IMapper _mapper;

        public GetListLikeQueryHandler(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLikeListItemDto>> Handle(GetListLikeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Like> likes = await _likeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLikeListItemDto> response = _mapper.Map<GetListResponse<GetListLikeListItemDto>>(likes);
            return response;
        }
    }
}