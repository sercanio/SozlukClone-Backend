using Application.Features.Titles.Constants;
using Application.Features.Titles.Rules;
using Application.Services.Authors;
using Application.Services.Repositories;
using Application.Services.TitleSettings;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using static Application.Features.Entries.Constants.EntriesOperationClaims;

namespace Application.Features.Titles.Commands.Create;

public class CreateTitleCommand : IRequest<CreatedTitleResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required uint AuthorId { get; set; }

    public string[] Roles => [Admin, Write, TitlesOperationClaims.Create];


    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, CreatedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;
        private readonly IAuthorService _authorService;
        private readonly ITitleSettingService _titleSettingService;
        public CreateTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository,
                                         TitleBusinessRules titleBusinessRules, IAuthorService authorService, ITitleSettingService titleSettingService)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
            _authorService = authorService;
            _titleSettingService = titleSettingService;
        }

        public async Task<CreatedTitleResponse> Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            Title title = _mapper.Map<Title>(request);
            title.slug = TitleUtils.GenerateSlug(title.Name);
            title.Name = title.Name.Trim().ToLower();

            await _titleBusinessRules.TitleNameShouldNotExistsWhenInsert(title.Name);

            TitleSetting? titleSettings = await _titleSettingService.GetAsync(predicate: s => s.Id == 1);
            if (titleSettings == null)
            {
                throw new Exception("Title settings not found.");
            }
            await _titleBusinessRules.TitleShouldHaveMinLength(title.Name, titleSettings.MinTitleLength);
            await _titleBusinessRules.TitleShouldHaveMaxLength(title.Name, titleSettings.MaxTitleLength);
            await _titleBusinessRules.TitleCanHaveSpecialCharachters(title.Name, titleSettings.TitleCanHaveSpecialCharacter);
            await _titleBusinessRules.TitleCanHavePunctuations(title.Name, titleSettings.TitleCanHavePunctuation);

            Author? author = await _authorService.GetAsync(predicate: a => a.Id == title.AuthorId);

            if (author is not null)
            {
                //var savedTitle = await _titleRepository.AddAsync(title);
                var savedTitle = await _titleRepository.AddAsync(title, cancellationToken);
                author.Titles.Add(savedTitle);
                await _authorService.UpdateAsync(author);
            }
            CreatedTitleResponse response = _mapper.Map<CreatedTitleResponse>(title);
            return response;
        }
    }
}