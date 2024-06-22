using NArchitecture.Core.Application.Responses;

namespace Application.Features.Categories.Commands.Create;

public class CreatedCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}