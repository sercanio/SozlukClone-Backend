using Application.Features.Badges.Constants;
using Application.Features.Badges.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Badges.Constants.BadgesOperationClaims;

namespace Application.Features.Badges.Queries.GetById;

public class GetByIdBadgeQuery : IRequest<GetByIdBadgeResponse>, ISecuredRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBadgeQueryHandler : IRequestHandler<GetByIdBadgeQuery, GetByIdBadgeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBadgeRepository _badgeRepository;
        private readonly BadgeBusinessRules _badgeBusinessRules;

        public GetByIdBadgeQueryHandler(IMapper mapper, IBadgeRepository badgeRepository, BadgeBusinessRules badgeBusinessRules)
        {
            _mapper = mapper;
            _badgeRepository = badgeRepository;
            _badgeBusinessRules = badgeBusinessRules;
        }

        public async Task<GetByIdBadgeResponse> Handle(GetByIdBadgeQuery request, CancellationToken cancellationToken)
        {
            Badge? badge = await _badgeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _badgeBusinessRules.BadgeShouldExistWhenSelected(badge);

            GetByIdBadgeResponse response = _mapper.Map<GetByIdBadgeResponse>(badge);
            return response;
        }
    }
}