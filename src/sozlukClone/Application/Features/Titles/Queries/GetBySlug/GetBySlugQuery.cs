using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Titles.Queries.GetBySlug;

public class GetBySlugQuery : IRequest<GetTitleBySlugResponse>
{
    public string Slug { get; set; }

    public class GetBySlugQueryHandler : IRequestHandler<GetBySlugQuery, GetTitleBySlugResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public GetBySlugQueryHandler(IMapper mapper, TitleBusinessRules titleBusinessRules, ITitleRepository titleRepository)
        {
            _mapper = mapper;
            _titleBusinessRules = titleBusinessRules;
            _titleRepository = titleRepository;
        }

        public async Task<GetTitleBySlugResponse> Handle(GetBySlugQuery request, CancellationToken cancellationToken)
        {
            Title? title = await _titleRepository.GetAsync(
                predicate: t => t.Slug == request.Slug,
                include: t => t.Include(t => t.Author),
                cancellationToken: cancellationToken);

            await _titleBusinessRules.TitleShouldExistWhenSelected(title);

            GetTitleBySlugResponse response = _mapper.Map<GetTitleBySlugResponse>(title);

            return response;
        }
    }
}
