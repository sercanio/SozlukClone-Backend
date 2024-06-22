using Application.Features.TitleFollowings.Constants;
using Application.Features.TitleFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using static Application.Features.TitleFollowings.Constants.TitleFollowingsOperationClaims;

namespace Application.Features.TitleFollowings.Commands.Delete;

public class DeleteTitleFollowingCommand : IRequest<DeletedTitleFollowingResponse>, ISecuredRequest, ILoggableRequest
{
    public int TitleId { get; set; }
    public int AuthorId { get; set; }

    public string[] Roles => [Admin, Write, TitleFollowingsOperationClaims.Delete];

    public class DeleteTitleFollowingCommandHandler : IRequestHandler<DeleteTitleFollowingCommand, DeletedTitleFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleFollowingRepository _titleFollowingRepository;
        private readonly TitleFollowingBusinessRules _titleFollowingBusinessRules;

        public DeleteTitleFollowingCommandHandler(IMapper mapper, ITitleFollowingRepository titleFollowingRepository,
                                         TitleFollowingBusinessRules titleFollowingBusinessRules)
        {
            _mapper = mapper;
            _titleFollowingRepository = titleFollowingRepository;
            _titleFollowingBusinessRules = titleFollowingBusinessRules;
        }

        public async Task<DeletedTitleFollowingResponse> Handle(DeleteTitleFollowingCommand request, CancellationToken cancellationToken)
        {
            TitleFollowing? titleFollowing = await _titleFollowingRepository.GetAsync(
                    predicate: tf => tf.TitleId == request.TitleId && tf.AuthorId == request.AuthorId,
                    cancellationToken: cancellationToken);

            await _titleFollowingBusinessRules.TitleFollowingShouldExistWhenSelected(titleFollowing);

            await _titleFollowingRepository.DeleteAsync(titleFollowing!);

            DeletedTitleFollowingResponse response = _mapper.Map<DeletedTitleFollowingResponse>(titleFollowing);
            return response;
        }
    }
}