using Application.Features.Authors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Authors.Queries.GetById;

public class GetByIdAuthorQuery : IRequest<GetByIdAuthorResponse>
{
    public uint Id { get; set; }

    public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQuery, GetByIdAuthorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;

        public GetByIdAuthorQueryHandler(IMapper mapper, IAuthorRepository authorRepository, AuthorBusinessRules authorBusinessRules)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _authorBusinessRules = authorBusinessRules;
        }

        public async Task<GetByIdAuthorResponse> Handle(GetByIdAuthorQuery request, CancellationToken cancellationToken)
        {
            Author? author = await _authorRepository.GetAsync(
                 include: a => a.Include(a => a.Titles),
                predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);

            await _authorBusinessRules.AuthorShouldExistWhenSelected(author);
            GetByIdAuthorResponse response = _mapper.Map<GetByIdAuthorResponse>(author);
            return response;
        }
    }
}