using Application.Features.AuthorGroups.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AuthorGroups.Constants.AuthorGroupsOperationClaims;

namespace Application.Features.AuthorGroups.Queries.GetList;

public class GetListAuthorGroupQuery : IRequest<GetListResponse<GetListAuthorGroupListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAuthorGroupQueryHandler : IRequestHandler<GetListAuthorGroupQuery, GetListResponse<GetListAuthorGroupListItemDto>>
    {
        private readonly IAuthorGroupRepository _authorGroupRepository;
        private readonly IMapper _mapper;

        public GetListAuthorGroupQueryHandler(IAuthorGroupRepository authorGroupRepository, IMapper mapper)
        {
            _authorGroupRepository = authorGroupRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAuthorGroupListItemDto>> Handle(GetListAuthorGroupQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AuthorGroup> authorGroups = await _authorGroupRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAuthorGroupListItemDto> response = _mapper.Map<GetListResponse<GetListAuthorGroupListItemDto>>(authorGroups);
            return response;
        }
    }
}