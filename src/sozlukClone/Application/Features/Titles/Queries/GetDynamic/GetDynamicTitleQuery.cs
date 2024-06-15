using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.Titles.Queries.GetDynamic;
public class GetDynamicTitleQuery : IRequest<GetListResponse<GetDynamicTitleItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetDynamicTitleQueryHandler : IRequestHandler<GetDynamicTitleQuery, GetListResponse<GetDynamicTitleItemDto>>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        public GetDynamicTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicTitleItemDto>> Handle(GetDynamicTitleQuery request, CancellationToken cancellationToken)
        {
            var titles = await _titleRepository.GetListByDynamicAsync(request.DynamicQuery,
                predicate: t => t.Entries.Count > 0,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize
                );

            var response = _mapper.Map<GetListResponse<GetDynamicTitleItemDto>>(titles);

            return response;
        }
    }
}
