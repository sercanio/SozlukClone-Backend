using Application.Features.TitleBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TitleBlockings.Queries.GetById;

public class GetByIdTitleBlockingQuery : IRequest<GetByIdTitleBlockingResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTitleBlockingQueryHandler : IRequestHandler<GetByIdTitleBlockingQuery, GetByIdTitleBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleBlockingRepository _titleBlockingRepository;
        private readonly TitleBlockingBusinessRules _titleBlockingBusinessRules;

        public GetByIdTitleBlockingQueryHandler(IMapper mapper, ITitleBlockingRepository titleBlockingRepository, TitleBlockingBusinessRules titleBlockingBusinessRules)
        {
            _mapper = mapper;
            _titleBlockingRepository = titleBlockingRepository;
            _titleBlockingBusinessRules = titleBlockingBusinessRules;
        }

        public async Task<GetByIdTitleBlockingResponse> Handle(GetByIdTitleBlockingQuery request, CancellationToken cancellationToken)
        {
            TitleBlocking? titleBlocking = await _titleBlockingRepository.GetAsync(
                            predicate: tb => tb.Id == request.Id,
                            cancellationToken: cancellationToken);

            await _titleBlockingBusinessRules.TitleBlockingShouldExistWhenSelected(titleBlocking);

            GetByIdTitleBlockingResponse response = _mapper.Map<GetByIdTitleBlockingResponse>(titleBlocking);
            return response;
        }
    }
}