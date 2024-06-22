using Application.Features.TitleBlockings.Constants;
using Application.Features.TitleBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.TitleBlockings.Constants.TitleBlockingsOperationClaims;

namespace Application.Features.TitleBlockings.Commands.Update;

public class UpdateTitleBlockingCommand : IRequest<UpdatedTitleBlockingResponse>, ISecuredRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int TitleId { get; set; }
    public required int AuthorId { get; set; }

    public string[] Roles => [Admin, Write, TitleBlockingsOperationClaims.Update];

    public class UpdateTitleBlockingCommandHandler : IRequestHandler<UpdateTitleBlockingCommand, UpdatedTitleBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleBlockingRepository _titleBlockingRepository;
        private readonly TitleBlockingBusinessRules _titleBlockingBusinessRules;

        public UpdateTitleBlockingCommandHandler(IMapper mapper, ITitleBlockingRepository titleBlockingRepository,
                                         TitleBlockingBusinessRules titleBlockingBusinessRules)
        {
            _mapper = mapper;
            _titleBlockingRepository = titleBlockingRepository;
            _titleBlockingBusinessRules = titleBlockingBusinessRules;
        }

        public async Task<UpdatedTitleBlockingResponse> Handle(UpdateTitleBlockingCommand request, CancellationToken cancellationToken)
        {
            TitleBlocking? titleBlocking = await _titleBlockingRepository.GetAsync(predicate: tb => tb.Id == request.Id, cancellationToken: cancellationToken);
            await _titleBlockingBusinessRules.TitleBlockingShouldExistWhenSelected(titleBlocking);
            titleBlocking = _mapper.Map(request, titleBlocking);

            await _titleBlockingRepository.UpdateAsync(titleBlocking!);

            UpdatedTitleBlockingResponse response = _mapper.Map<UpdatedTitleBlockingResponse>(titleBlocking);
            return response;
        }
    }
}