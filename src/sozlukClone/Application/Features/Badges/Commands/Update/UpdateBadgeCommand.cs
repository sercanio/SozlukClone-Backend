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

namespace Application.Features.Badges.Commands.Update;

public class UpdateBadgeCommand : IRequest<UpdatedBadgeResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string IconUrl { get; set; }

    public string[] Roles => [Admin, Write, BadgesOperationClaims.Update];

    public class UpdateBadgeCommandHandler : IRequestHandler<UpdateBadgeCommand, UpdatedBadgeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBadgeRepository _badgeRepository;
        private readonly BadgeBusinessRules _badgeBusinessRules;

        public UpdateBadgeCommandHandler(IMapper mapper, IBadgeRepository badgeRepository,
                                         BadgeBusinessRules badgeBusinessRules)
        {
            _mapper = mapper;
            _badgeRepository = badgeRepository;
            _badgeBusinessRules = badgeBusinessRules;
        }

        public async Task<UpdatedBadgeResponse> Handle(UpdateBadgeCommand request, CancellationToken cancellationToken)
        {
            Badge? badge = await _badgeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _badgeBusinessRules.BadgeShouldExistWhenSelected(badge);
            badge = _mapper.Map(request, badge);

            await _badgeRepository.UpdateAsync(badge!);

            UpdatedBadgeResponse response = _mapper.Map<UpdatedBadgeResponse>(badge);
            return response;
        }
    }
}