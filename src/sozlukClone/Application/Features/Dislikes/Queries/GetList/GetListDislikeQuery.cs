using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Dislikes.Queries.GetList;

public class GetListDislikeQuery : IRequest<GetListResponse<GetListDislikeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListDislikeQueryHandler : IRequestHandler<GetListDislikeQuery, GetListResponse<GetListDislikeListItemDto>>
    {
        private readonly IDislikeRepository _dislikeRepository;
        private readonly IMapper _mapper;

        public GetListDislikeQueryHandler(IDislikeRepository dislikeRepository, IMapper mapper)
        {
            _dislikeRepository = dislikeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListDislikeListItemDto>> Handle(GetListDislikeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Dislike> dislikes = await _dislikeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListDislikeListItemDto> response = _mapper.Map<GetListResponse<GetListDislikeListItemDto>>(dislikes);
            return response;
        }
    }
}