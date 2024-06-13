using FluentValidation;

namespace Application.Features.Titles.Queries.GetBySlug;

public class GetBySlugQueryValidator : AbstractValidator<GetBySlugQuery>
{
    public GetBySlugQueryValidator() { }
}