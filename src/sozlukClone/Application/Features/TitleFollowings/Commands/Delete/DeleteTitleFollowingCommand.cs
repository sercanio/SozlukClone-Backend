using Application.Features.TitleFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TitleFollowings.Commands.Delete;

public class DeleteTitleFollowingCommand : IRequest<DeletedTitleFollowingResponse>
{
    public Guid Id { get; set; }

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
            await _titleFollowingBusinessRules.TitleFollowingIdShouldExistWhenSelected(request.Id, cancellationToken);

            TitleFollowing? titleFollowing = await _titleFollowingRepository.GetAsync(
                predicate: tf => tf.Id == request.Id,
                enableTracking: false,
                cancellationToken: cancellationToken);

            _titleFollowingRepository.Delete(titleFollowing!);

            DeletedTitleFollowingResponse response = _mapper.Map<DeletedTitleFollowingResponse>(titleFollowing);
            return response;
        }
    }
}