using Application.Features.AuthorBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.AuthorBlockings.Commands.Delete;

public class DeleteAuthorBlockingCommand : IRequest<DeletedAuthorBlockingResponse>, ILoggableRequest
{
    public Guid Id { get; set; }

    public class DeleteAuthorBlockingCommandHandler : IRequestHandler<DeleteAuthorBlockingCommand, DeletedAuthorBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorBlockingRepository _authorBlockingRepository;
        private readonly AuthorBlockingBusinessRules _authorBlockingBusinessRules;

        public DeleteAuthorBlockingCommandHandler(IMapper mapper, IAuthorBlockingRepository authorBlockingRepository,
                                         AuthorBlockingBusinessRules authorBlockingBusinessRules)
        {
            _mapper = mapper;
            _authorBlockingRepository = authorBlockingRepository;
            _authorBlockingBusinessRules = authorBlockingBusinessRules;
        }

        public async Task<DeletedAuthorBlockingResponse> Handle(DeleteAuthorBlockingCommand request, CancellationToken cancellationToken)
        {

            await _authorBlockingBusinessRules.AuthorBlockingIdShouldExistWhenSelected(request.Id, cancellationToken);

            AuthorBlocking? blocking = await _authorBlockingRepository.GetAsync(
                    predicate: ab => ab.Id == request.Id,
                    cancellationToken: cancellationToken);

            await _authorBlockingRepository.DeleteAsync(blocking!);

            DeletedAuthorBlockingResponse response = _mapper.Map<DeletedAuthorBlockingResponse>(blocking);
            return response;
        }
    }
}