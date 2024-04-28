using Application.Features.Badges.Constants;
using Application.Features.Badges.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Badges.Constants.BadgesOperationClaims;

namespace Application.Features.Badges.Commands.Create;

public class CreateBadgeCommand : IRequest<CreatedBadgeResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string IconUrl { get; set; }

    public string[] Roles => [Admin, Write, BadgesOperationClaims.Create];

    public class CreateBadgeCommandHandler : IRequestHandler<CreateBadgeCommand, CreatedBadgeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBadgeRepository _badgeRepository;
        private readonly BadgeBusinessRules _badgeBusinessRules;

        public CreateBadgeCommandHandler(IMapper mapper, IBadgeRepository badgeRepository,
                                         BadgeBusinessRules badgeBusinessRules)
        {
            _mapper = mapper;
            _badgeRepository = badgeRepository;
            _badgeBusinessRules = badgeBusinessRules;
        }

        public async Task<CreatedBadgeResponse> Handle(CreateBadgeCommand request, CancellationToken cancellationToken)
        {
            Badge badge = _mapper.Map<Badge>(request);

            await _badgeRepository.AddAsync(badge);

            CreatedBadgeResponse response = _mapper.Map<CreatedBadgeResponse>(badge);
            return response;
        }
    }
}