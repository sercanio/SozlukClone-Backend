using Application.Features.Titles.Constants;
using Application.Features.Titles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Titles.Constants.TitlesOperationClaims;

namespace Application.Features.Titles.Commands.Update;

public class UpdateTitleCommand : IRequest<UpdatedTitleResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }
    public required string Name { get; set; }
    public required uint AuthorId { get; set; }
    public required bool IsLocked { get; set; }
    public required string Slug { get; set; }

    public string[] Roles => [Admin, Write, TitlesOperationClaims.Update];

    public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand, UpdatedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public UpdateTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository,
                                         TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<UpdatedTitleResponse> Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
        {
            Title? title = await _titleRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _titleBusinessRules.TitleShouldExistWhenSelected(title);
            title = _mapper.Map(request, title);

            await _titleRepository.UpdateAsync(title!);

            UpdatedTitleResponse response = _mapper.Map<UpdatedTitleResponse>(title);
            return response;
        }
    }
}