using Application.Features.TitleBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.TitleBlockings.Commands.Create;

public class CreateTitleBlockingCommand : IRequest<CreatedTitleBlockingResponse>, ILoggableRequest
{
    public required int TitleId { get; set; }
    public required int AuthorId { get; set; }

    public class CreateTitleBlockingCommandHandler : IRequestHandler<CreateTitleBlockingCommand, CreatedTitleBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleBlockingRepository _titleBlockingRepository;
        private readonly TitleBlockingBusinessRules _titleBlockingBusinessRules;

        public CreateTitleBlockingCommandHandler(IMapper mapper, ITitleBlockingRepository titleBlockingRepository,
                                         TitleBlockingBusinessRules titleBlockingBusinessRules)
        {
            _mapper = mapper;
            _titleBlockingRepository = titleBlockingRepository;
            _titleBlockingBusinessRules = titleBlockingBusinessRules;
        }

        public async Task<CreatedTitleBlockingResponse> Handle(CreateTitleBlockingCommand request, CancellationToken cancellationToken)
        {
            TitleBlocking titleBlocking = _mapper.Map<TitleBlocking>(request);

            TitleBlocking? titleBlockingInDb = await _titleBlockingRepository.GetAsync(
                    predicate: t => t.TitleId == request.TitleId && t.AuthorId == request.AuthorId,
                    withDeleted: true
                    );

            if (titleBlockingInDb != null && titleBlockingInDb.DeletedDate != null)
            {
                titleBlockingInDb.DeletedDate = null;
                await _titleBlockingRepository.UpdateAsync(titleBlockingInDb);

                CreatedTitleBlockingResponse updatedBlocking = _mapper.Map<CreatedTitleBlockingResponse>(titleBlockingInDb);
                return updatedBlocking;
            }

            await _titleBlockingRepository.AddAsync(titleBlocking);

            CreatedTitleBlockingResponse response = _mapper.Map<CreatedTitleBlockingResponse>(titleBlocking);
            return response;
        }
    }
}