using Application.Features.TitleBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.TitleBlockings.Commands.Delete;

public class DeleteTitleBlockingCommand : IRequest<DeletedTitleBlockingResponse>, ILoggableRequest
{
    public Guid Id { get; set; }

    public class DeleteTitleBlockingCommandHandler : IRequestHandler<DeleteTitleBlockingCommand, DeletedTitleBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleBlockingRepository _titleBlockingRepository;
        private readonly TitleBlockingBusinessRules _titleBlockingBusinessRules;

        public DeleteTitleBlockingCommandHandler(IMapper mapper, ITitleBlockingRepository titleBlockingRepository,
                                         TitleBlockingBusinessRules titleBlockingBusinessRules)
        {
            _mapper = mapper;
            _titleBlockingRepository = titleBlockingRepository;
            _titleBlockingBusinessRules = titleBlockingBusinessRules;
        }

        public async Task<DeletedTitleBlockingResponse> Handle(DeleteTitleBlockingCommand request, CancellationToken cancellationToken)
        {
            await _titleBlockingBusinessRules.TitleBlockingIdShouldExistWhenSelected(request.Id, cancellationToken);

            TitleBlocking? titleBlocking = await _titleBlockingRepository.GetAsync(
                                predicate: tb => tb.Id == request.Id,
                                cancellationToken: cancellationToken);

            await _titleBlockingRepository.DeleteAsync(titleBlocking!);

            DeletedTitleBlockingResponse response = _mapper.Map<DeletedTitleBlockingResponse>(titleBlocking);
            return response;
        }
    }
}