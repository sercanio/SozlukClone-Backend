using Application.Features.AuthorBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.AuthorBlockings.Commands.Update;

public class UpdateAuthorBlockingCommand : IRequest<UpdatedAuthorBlockingResponse>, ILoggableRequest
{
    public Guid Id { get; set; }
    public required int BlockerId { get; set; }
    public required int BlockingId { get; set; }

    public class UpdateAuthorBlockingCommandHandler : IRequestHandler<UpdateAuthorBlockingCommand, UpdatedAuthorBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorBlockingRepository _authorBlockingRepository;
        private readonly AuthorBlockingBusinessRules _authorBlockingBusinessRules;

        public UpdateAuthorBlockingCommandHandler(IMapper mapper, IAuthorBlockingRepository authorBlockingRepository,
                                         AuthorBlockingBusinessRules authorBlockingBusinessRules)
        {
            _mapper = mapper;
            _authorBlockingRepository = authorBlockingRepository;
            _authorBlockingBusinessRules = authorBlockingBusinessRules;
        }

        public async Task<UpdatedAuthorBlockingResponse> Handle(UpdateAuthorBlockingCommand request, CancellationToken cancellationToken)
        {
            AuthorBlocking? authorBlocking = await _authorBlockingRepository.GetAsync(predicate: ab => ab.Id == request.Id, cancellationToken: cancellationToken);
            await _authorBlockingBusinessRules.AuthorBlockingShouldExistWhenSelected(authorBlocking);
            authorBlocking = _mapper.Map(request, authorBlocking);

            await _authorBlockingRepository.UpdateAsync(authorBlocking!);

            UpdatedAuthorBlockingResponse response = _mapper.Map<UpdatedAuthorBlockingResponse>(authorBlocking);
            return response;
        }
    }
}