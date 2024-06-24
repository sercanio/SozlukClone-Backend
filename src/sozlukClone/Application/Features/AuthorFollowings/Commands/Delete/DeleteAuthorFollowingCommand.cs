using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

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
            await _authorFollowingBusinessRules.AuthorFollowingIdShouldExistWhenSelected(request.Id, cancellationToken);

            AuthorFollowing? following = await _authorFollowingRepository.GetAsync(
                    predicate: d => d.Id == request.Id,
                    cancellationToken: cancellationToken
                    );

            await _authorFollowingRepository.DeleteAsync(following!);

            DeletedAuthorFollowingResponse response = _mapper.Map<DeletedAuthorFollowingResponse>(following);
            return response;
        }
    }
}