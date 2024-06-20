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
                 include: a => a.Include(a => a.Titles)
                                .Include(a => a.User)
                                .Include(a => a.Entries),
                predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);

            await _authorBusinessRules.AuthorShouldExistWhenSelected(author);

            Author? authorToCount = await _authorRepository.GetAsync(
                predicate: a => a.Id == author!.Id,
                include: a => a.Include(a => a.Titles).Include(a => a.Titles),
                cancellationToken: cancellationToken);

            GetByIdAuthorResponse response = _mapper.Map<GetByIdAuthorResponse>(author);

            response.EntryCount = authorToCount.Entries.Count;
            response.TitleCount = authorToCount.Titles.Count;

            return response;
        }
    }
}