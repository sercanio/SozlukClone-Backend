using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.AuthorFollowings.Commands.Update;

public class UpdateAuthorFollowingCommand : IRequest<UpdatedAuthorFollowingResponse>, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int FollowerId { get; set; }
    public required int FollowingId { get; set; }

    public class UpdateAuthorFollowingCommandHandler : IRequestHandler<UpdateAuthorFollowingCommand, UpdatedAuthorFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorFollowingRepository _authorFollowingRepository;
        private readonly AuthorFollowingBusinessRules _authorFollowingBusinessRules;

        public UpdateAuthorFollowingCommandHandler(IMapper mapper, IAuthorFollowingRepository authorFollowingRepository,
                                         AuthorFollowingBusinessRules authorFollowingBusinessRules)
        {
            _mapper = mapper;
            _authorFollowingRepository = authorFollowingRepository;
            _authorFollowingBusinessRules = authorFollowingBusinessRules;
        }

        public async Task<UpdatedAuthorFollowingResponse> Handle(UpdateAuthorFollowingCommand request, CancellationToken cancellationToken)
        {
            AuthorFollowing? authorFollowing = await _authorFollowingRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _authorFollowingBusinessRules.AuthorFollowingShouldExistWhenSelected(authorFollowing);
            authorFollowing = _mapper.Map(request, authorFollowing);

            await _authorFollowingRepository.UpdateAsync(authorFollowing!);

            UpdatedAuthorFollowingResponse response = _mapper.Map<UpdatedAuthorFollowingResponse>(authorFollowing);
            return response;
        }
    }
}