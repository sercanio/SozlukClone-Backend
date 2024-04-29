using Application.Features.Titles.Constants;
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

namespace Application.Features.Titles.Commands.Delete;

public class DeleteTitleCommand : IRequest<DeletedTitleResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public uint Id { get; set; }

    public string[] Roles => [Admin, Write, TitlesOperationClaims.Delete];

    public class DeleteTitleCommandHandler : IRequestHandler<DeleteTitleCommand, DeletedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public DeleteTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository,
                                         TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<DeletedTitleResponse> Handle(DeleteTitleCommand request, CancellationToken cancellationToken)
        {
            Title? title = await _titleRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _titleBusinessRules.TitleShouldExistWhenSelected(title);

            await _titleRepository.DeleteAsync(title!);

            DeletedTitleResponse response = _mapper.Map<DeletedTitleResponse>(title);
            return response;
        }
    }
}