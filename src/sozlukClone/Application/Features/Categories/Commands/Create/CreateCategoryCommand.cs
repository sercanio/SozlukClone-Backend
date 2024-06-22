using Application.Features.Categories.Constants;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.Categories.Constants.CategoriesOperationClaims;

namespace Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<CreatedCategoryResponse>, ISecuredRequest, ILoggableRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public string[] Roles => [Admin, Write, CategoriesOperationClaims.Create];

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryBusinessRules _categoryBusinessRules;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository,
                                         CategoryBusinessRules categoryBusinessRules)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<CreatedCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(category);

            CreatedCategoryResponse response = _mapper.Map<CreatedCategoryResponse>(category);
            return response;
        }
    }
}