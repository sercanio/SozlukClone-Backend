using Application.Features.Authors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Authors.Queries.GetByUserName;

public class GetByUserNameQuery : IRequest<GetByUserNameResponse>
{
    public string UserName { get; set; }
    public class GetByUserNameQueryHandler : IRequestHandler<GetByUserNameQuery, GetByUserNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly AuthorBusinessRules _authorBusinessRules;
        private readonly IAuthorRepository _authorRepository;

        public GetByUserNameQueryHandler(IMapper mapper, AuthorBusinessRules authorBusinessRules, IAuthorRepository authorRepository)
        {
            _mapper = mapper;
            _authorBusinessRules = authorBusinessRules;
            _authorRepository = authorRepository;
        }

        public async Task<GetByUserNameResponse> Handle(GetByUserNameQuery request, CancellationToken cancellationToken)
        {
            Author? author = await _authorRepository.GetAsync(predicate: a => a.UserName == request.UserName, cancellationToken: cancellationToken);
            GetByUserNameResponse response = _mapper.Map<GetByUserNameResponse>(author);
            return response;
        }
    }
}
