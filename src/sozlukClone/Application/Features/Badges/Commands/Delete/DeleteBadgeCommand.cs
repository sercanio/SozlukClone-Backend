using Application.Features.Badges.Constants;
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

namespace Application.Features.Badges.Commands.Delete;

public class DeleteBadgeCommand : IRequest<DeletedBadgeResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Write, BadgesOperationClaims.Delete];

    public class DeleteBadgeCommandHandler : IRequestHandler<DeleteBadgeCommand, DeletedBadgeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBadgeRepository _badgeRepository;
        private readonly BadgeBusinessRules _badgeBusinessRules;

        public DeleteBadgeCommandHandler(IMapper mapper, IBadgeRepository badgeRepository,
                                         BadgeBusinessRules badgeBusinessRules)
        {
            _mapper = mapper;
            _badgeRepository = badgeRepository;
            _badgeBusinessRules = badgeBusinessRules;
        }

        public async Task<DeletedBadgeResponse> Handle(DeleteBadgeCommand request, CancellationToken cancellationToken)
        {
            Badge? badge = await _badgeRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _badgeBusinessRules.BadgeShouldExistWhenSelected(badge);

            await _badgeRepository.DeleteAsync(badge!);

            DeletedBadgeResponse response = _mapper.Map<DeletedBadgeResponse>(badge);
            return response;
        }
    }
}