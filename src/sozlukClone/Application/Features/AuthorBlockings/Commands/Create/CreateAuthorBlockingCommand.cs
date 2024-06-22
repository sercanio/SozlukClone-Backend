using Application.Features.AuthorBlockings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.AuthorBlockings.Commands.Create;

public class CreateAuthorBlockingCommand : IRequest<CreatedAuthorBlockingResponse>, ILoggableRequest
{
    public required int BlockingId { get; set; }
    public required int BlockerId { get; set; }

    public class CreateAuthorBlockingCommandHandler : IRequestHandler<CreateAuthorBlockingCommand, CreatedAuthorBlockingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAuthorBlockingRepository _authorBlockingRepository;
        private readonly AuthorBlockingBusinessRules _authorBlockingBusinessRules;

        public CreateAuthorBlockingCommandHandler(IMapper mapper, IAuthorBlockingRepository authorBlockingRepository,
                                         AuthorBlockingBusinessRules authorBlockingBusinessRules)
        {
            _mapper = mapper;
            _authorBlockingRepository = authorBlockingRepository;
            _authorBlockingBusinessRules = authorBlockingBusinessRules;
        }

        public async Task<CreatedAuthorBlockingResponse> Handle(CreateAuthorBlockingCommand request, CancellationToken cancellationToken)
        {
            AuthorBlocking authorBlocking = _mapper.Map<AuthorBlocking>(request);

            AuthorBlocking? authorBlockingInDb = await _authorBlockingRepository.GetAsync(
                    predicate: af => af.BlockingId == request.BlockingId && af.BlockerId == request.BlockerId,
                    withDeleted: true
                    );

            if (authorBlockingInDb != null && authorBlockingInDb.DeletedDate != null)
            {
                authorBlockingInDb.DeletedDate = null;
                await _authorBlockingRepository.UpdateAsync(authorBlockingInDb);

                CreatedAuthorBlockingResponse updatedBlocking = _mapper.Map<CreatedAuthorBlockingResponse>(authorBlockingInDb);
                return updatedBlocking;
            }

            await _authorBlockingRepository.AddAsync(authorBlocking);

            CreatedAuthorBlockingResponse response = _mapper.Map<CreatedAuthorBlockingResponse>(authorBlocking);
            return response;
        }
    }
}