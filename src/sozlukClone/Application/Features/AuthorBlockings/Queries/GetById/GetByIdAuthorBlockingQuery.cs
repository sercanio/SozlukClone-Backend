using Application.Features.AuthorBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.AuthorBlockings.Queries.GetById;

public class GetByIdAuthorBlockingQuery : IRequest<GetByIdAuthorBlockingResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAuthorBlockingQueryHandler : IRequestHandler<GetByIdAuthorBlockingQuery, GetByIdAuthorBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorBlockingRepository _authorBlockingRepository;
        private readonly AuthorBlockingBusinessRules _authorBlockingBusinessRules;

        public GetByIdAuthorBlockingQueryHandler(IMapper mapper, IAuthorBlockingRepository authorBlockingRepository, AuthorBlockingBusinessRules authorBlockingBusinessRules)
        {
            _mapper = mapper;
            _authorBlockingRepository = authorBlockingRepository;
            _authorBlockingBusinessRules = authorBlockingBusinessRules;
        }

        public async Task<GetByIdAuthorBlockingResponse> Handle(GetByIdAuthorBlockingQuery request, CancellationToken cancellationToken)
        {
            AuthorBlocking? authorBlocking = await _authorBlockingRepository.GetAsync(predicate: ab => ab.Id == request.Id, cancellationToken: cancellationToken);
            await _authorBlockingBusinessRules.AuthorBlockingShouldExistWhenSelected(authorBlocking);

            GetByIdAuthorBlockingResponse response = _mapper.Map<GetByIdAuthorBlockingResponse>(authorBlocking);
            return response;
        }
    }
}