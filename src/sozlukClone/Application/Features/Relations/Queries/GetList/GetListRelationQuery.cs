using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Relations.Queries.GetList;

public class GetListRelationQuery : IRequest<GetListResponse<GetListRelationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListRelationQueryHandler : IRequestHandler<GetListRelationQuery, GetListResponse<GetListRelationListItemDto>>
    {
        private readonly IRelationRepository _relationRepository;
        private readonly IMapper _mapper;

        public GetListRelationQueryHandler(IRelationRepository relationRepository, IMapper mapper)
        {
            _relationRepository = relationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRelationListItemDto>> Handle(GetListRelationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Relation> relations = await _relationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRelationListItemDto> response = _mapper.Map<GetListResponse<GetListRelationListItemDto>>(relations);
            return response;
        }
    }
}