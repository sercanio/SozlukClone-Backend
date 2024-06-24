using Application.Features.TitleFollowings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.TitleFollowings.Commands.Create;

public class CreateTitleFollowingCommand : IRequest<CreatedTitleFollowingResponse>, ILoggableRequest
{
    public required int TitleId { get; set; }
    public required int AuthorId { get; set; }

    public class CreateTitleFollowingCommandHandler : IRequestHandler<CreateTitleFollowingCommand, CreatedTitleFollowingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleFollowingRepository _titleFollowingRepository;
        private readonly TitleFollowingBusinessRules _titleFollowingBusinessRules;

        public CreateTitleFollowingCommandHandler(IMapper mapper, ITitleFollowingRepository titleFollowingRepository,
                                         TitleFollowingBusinessRules titleFollowingBusinessRules)
        {
            _mapper = mapper;
            _titleFollowingRepository = titleFollowingRepository;
            _titleFollowingBusinessRules = titleFollowingBusinessRules;
        }

        public async Task<CreatedTitleFollowingResponse> Handle(CreateTitleFollowingCommand request, CancellationToken cancellationToken)
        {
            TitleFollowing titleFollowing = _mapper.Map<TitleFollowing>(request);

            await _titleFollowingBusinessRules.TitleFollowingShouldNotDuplicatedWhenInserted(titleFollowing, cancellationToken);
            await _titleFollowingBusinessRules.TitleBlockingShouldNotExistWhenFollowingInserted(titleFollowing, cancellationToken);

            await _titleFollowingRepository.AddAsync(titleFollowing);

            CreatedTitleFollowingResponse response = _mapper.Map<CreatedTitleFollowingResponse>(titleFollowing);
            return response;
        }
    }
}