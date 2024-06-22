using Application.Features.AuthorFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.AuthorFollowings.Commands.Create;

public class CreateAuthorFollowingCommand : IRequest<CreatedAuthorFollowingResponse>, ILoggableRequest
{
    public required int FollowingId { get; set; }
    public required int FollowerId { get; set; }

    public class CreateAuthorFollowingCommandHandler : IRequestHandler<CreateAuthorFollowingCommand, CreatedAuthorFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorFollowingRepository _authorFollowingRepository;
        private readonly AuthorFollowingBusinessRules _authorFollowingBusinessRules;

        public CreateAuthorFollowingCommandHandler(IMapper mapper, IAuthorFollowingRepository authorFollowingRepository,
                                         AuthorFollowingBusinessRules authorFollowingBusinessRules)
        {
            _mapper = mapper;
            _authorFollowingRepository = authorFollowingRepository;
            _authorFollowingBusinessRules = authorFollowingBusinessRules;
        }

        public async Task<CreatedAuthorFollowingResponse> Handle(CreateAuthorFollowingCommand request, CancellationToken cancellationToken)
        {
            AuthorFollowing authorFollowing = _mapper.Map<AuthorFollowing>(request);

            AuthorFollowing? authorFollowingInDb = await _authorFollowingRepository.GetAsync(
                    predicate: af => af.FollowerId == request.FollowerId && af.FollowingId == request.FollowingId,
                    withDeleted: true
                    );

            if (authorFollowingInDb != null && authorFollowingInDb.DeletedDate != null)
            {
                authorFollowingInDb.DeletedDate = null;
                await _authorFollowingRepository.UpdateAsync(authorFollowingInDb);

                CreatedAuthorFollowingResponse updatedFollowing = _mapper.Map<CreatedAuthorFollowingResponse>(authorFollowingInDb);
                return updatedFollowing;
            }

            await _authorFollowingRepository.AddAsync(authorFollowing);

            CreatedAuthorFollowingResponse response = _mapper.Map<CreatedAuthorFollowingResponse>(authorFollowing);
            return response;
        }
    }
}