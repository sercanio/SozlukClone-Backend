using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorBlockings.Queries.GetList;

public class GetListAuthorBlockingQuery : IRequest<GetListResponse<GetListAuthorBlockingListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAuthorBlockingQueryHandler : IRequestHandler<GetListAuthorBlockingQuery, GetListResponse<GetListAuthorBlockingListItemDto>>
    {
        private readonly IAuthorBlockingRepository _authorBlockingRepository;
        private readonly IMapper _mapper;

        public GetListAuthorBlockingQueryHandler(IAuthorBlockingRepository authorBlockingRepository, IMapper mapper)
        {
            _authorBlockingRepository = authorBlockingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorBlockingListItemDto>> Handle(GetListAuthorBlockingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorBlocking> authorBlockings = await _authorBlockingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorBlockingListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorBlockingListItemDto>>(authorBlockings);
            return response;
        }
    }
}