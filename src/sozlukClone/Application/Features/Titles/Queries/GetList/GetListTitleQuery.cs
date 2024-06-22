using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Titles.Queries.GetList;

public class GetListTitleQuery : IRequest<GetListResponse<GetListTitleListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTitleQueryHandler : IRequestHandler<GetListTitleQuery, GetListResponse<GetListTitleListItemDto>>
    {
        private readonly ITitleRepository _titleRepository;
        private readonly IMapper _mapper;

        public GetListTitleQueryHandler(ITitleRepository titleRepository, IMapper mapper)
        {
            _titleRepository = titleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTitleListItemDto>> Handle(GetListTitleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Title> titles = await _titleRepository.GetListAsync(
                predicate: t => t.Entries.Count > 0,
                include: t => t.Include(t => t.Entries),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                orderBy: q => q.OrderByDescending(t => t.Entries.Max(e => e.CreatedDate)),
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTitleListItemDto> titlesToMap = _mapper.Map<GetListResponse<GetListTitleListItemDto>>(titles);

            foreach (var item in titlesToMap.Items)
            {
                item.EntryCount = item.Entries.Count;
            }

            foreach (var item in titlesToMap.Items)
            {
                item.Entries = [];
            }

            GetListResponse<GetListTitleListItemDto> response = _mapper.Map<GetListResponse<GetListTitleListItemDto>>(titlesToMap);

            return response;
        }
    }
}