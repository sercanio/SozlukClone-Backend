using Application.Features.AuthorFollowings.Constants;
using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;

namespace Application.Features.AuthorFollowings.Commands.Delete;

public class DeleteAuthorFollowingCommand : IRequest<DeletedAuthorFollowingResponse>, ILoggableRequest
{
    public Guid Id { get; set; }

    public class DeleteAuthorFollowingCommandHandler : IRequestHandler<DeleteAuthorFollowingCommand, DeletedAuthorFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorFollowingRepository _authorFollowingRepository;
        private readonly AuthorFollowingBusinessRules _authorFollowingBusinessRules;

        public DeleteAuthorFollowingCommandHandler(IMapper mapper, IAuthorFollowingRepository authorFollowingRepository,
                                         AuthorFollowingBusinessRules authorFollowingBusinessRules)
        {
            _mapper = mapper;
            _authorFollowingRepository = authorFollowingRepository;
            _authorFollowingBusinessRules = authorFollowingBusinessRules;
        }

        public async Task<DeletedAuthorFollowingResponse> Handle(DeleteAuthorFollowingCommand request, CancellationToken cancellationToken)
        {
            AuthorFollowing? authorFollowing = await _authorFollowingRepository.GetAsync(predicate: af => af.Id == request.Id, cancellationToken: cancellationToken);
            await _authorFollowingBusinessRules.AuthorFollowingShouldExistWhenSelected(authorFollowing);

            await _authorFollowingRepository.DeleteAsync(authorFollowing!);

            DeletedAuthorFollowingResponse response = _mapper.Map<DeletedAuthorFollowingResponse>(authorFollowing);
            return response;
        }
    }
}