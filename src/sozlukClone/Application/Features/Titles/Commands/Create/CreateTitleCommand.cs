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

namespace Application.Features.Titles.Commands.Create;

public class CreateTitleCommand : IRequest<CreatedTitleResponse>, ISecuredRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Name { get; set; }
    public required uint AuthorId { get; set; }
    public required bool IsLocked { get; set; }

    public string[] Roles => [Admin, Write, TitlesOperationClaims.Create];

    public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, CreatedTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITitleRepository _titleRepository;
        private readonly TitleBusinessRules _titleBusinessRules;

        public CreateTitleCommandHandler(IMapper mapper, ITitleRepository titleRepository,
                                         TitleBusinessRules titleBusinessRules)
        {
            _mapper = mapper;
            _titleRepository = titleRepository;
            _titleBusinessRules = titleBusinessRules;
        }

        public async Task<CreatedTitleResponse> Handle(CreateTitleCommand request, CancellationToken cancellationToken)
        {
            Title title = _mapper.Map<Title>(request);

            await _titleRepository.AddAsync(title);

            CreatedTitleResponse response = _mapper.Map<CreatedTitleResponse>(title);
            return response;
        }
    }
}