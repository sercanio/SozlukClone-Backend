using Application.Features.Authors.Queries.GetDynamic;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.Titles.Queries.GetDynamic;
public class GetDynamicAuthorQuery : IRequest<GetListResponse<GetDynamicAuthorItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetDynamicAuthorQueryHandler : IRequestHandler<GetDynamicAuthorQuery, GetListResponse<GetDynamicAuthorItemDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetDynamicAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetDynamicAuthorItemDto>> Handle(GetDynamicAuthorQuery request, CancellationToken cancellationToken)
        {
            var titles = await _authorRepository.GetListByDynamicAsync(request.DynamicQuery, index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize);

            var response = _mapper.Map<GetListResponse<GetDynamicAuthorItemDto>>(titles);

            return response;
        }
    }
}
