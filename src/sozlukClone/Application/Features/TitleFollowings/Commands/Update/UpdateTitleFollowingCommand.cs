using Application.Features.TitleFollowings.Constants;
using Application.Features.TitleFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.TitleFollowings.Constants.TitleFollowingsOperationClaims;

namespace Application.Features.TitleFollowings.Commands.Update;

public class UpdateTitleFollowingCommand : IRequest<UpdatedTitleFollowingResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int TitleId { get; set; }
    public required int AuthorId { get; set; }

    public string[] Roles => [Admin, Write, TitleFollowingsOperationClaims.Update];

    public class UpdateTitleFollowingCommandHandler : IRequestHandler<UpdateTitleFollowingCommand, UpdatedTitleFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleFollowingRepository _titleFollowingRepository;
        private readonly TitleFollowingBusinessRules _titleFollowingBusinessRules;

        public UpdateTitleFollowingCommandHandler(IMapper mapper, ITitleFollowingRepository titleFollowingRepository,
                                         TitleFollowingBusinessRules titleFollowingBusinessRules)
        {
            _mapper = mapper;
            _titleFollowingRepository = titleFollowingRepository;
            _titleFollowingBusinessRules = titleFollowingBusinessRules;
        }

        public async Task<UpdatedTitleFollowingResponse> Handle(UpdateTitleFollowingCommand request, CancellationToken cancellationToken)
        {
            TitleFollowing? titleFollowing = await _titleFollowingRepository.GetAsync(predicate: tf => tf.Id == request.Id, cancellationToken: cancellationToken);
            await _titleFollowingBusinessRules.TitleFollowingShouldExistWhenSelected(titleFollowing);
            titleFollowing = _mapper.Map(request, titleFollowing);

            await _titleFollowingRepository.UpdateAsync(titleFollowing!);

            UpdatedTitleFollowingResponse response = _mapper.Map<UpdatedTitleFollowingResponse>(titleFollowing);
            return response;
        }
    }
}