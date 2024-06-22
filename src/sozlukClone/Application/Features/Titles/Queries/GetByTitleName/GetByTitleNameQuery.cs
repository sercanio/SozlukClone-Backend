using Application.Features.Titles.Queries.GetBySlug;
using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Titles.Queries.GetByTitleName;

public class GetByTitleNameQuery : IRequest<GetByTitleNameResponse>
{
    public string Name { get; set; }

    public class GetByTitleNameQueryHandler : IRequestHandler<GetByTitleNameQuery, GetByTitleNameResponse>
    {
        private readonly IMapper _mapper;
        private readonly TitleBusinessRules _titleBusinessRules;
        private readonly ITitleRepository _titleRepository;

        public GetByTitleNameQueryHandler(IMapper mapper, TitleBusinessRules titleBusinessRules, ITitleRepository titleRepository)
        {
            _mapper = mapper;
            _titleBusinessRules = titleBusinessRules;
            _titleRepository = titleRepository;
        }

        public async Task<GetByTitleNameResponse> Handle(GetByTitleNameQuery request, CancellationToken cancellationToken)
        {
            Title? title = await _titleRepository.GetAsync(predicate: t => t.Name == request.Name.Trim(),
                include: t => t.Include(t => t.Entries).Include(t => t.Author),
                cancellationToken: cancellationToken);

            await _titleBusinessRules.TitleShouldExistWhenSelected(title);

            GetByTitleNameResponse response = _mapper.Map<GetByTitleNameResponse>(title);
            return response;
        }
    }
}
