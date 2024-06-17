using FluentValidation;

namespace Application.Features.Titles.Queries.GetByTitleName;

public class GetByTitleNameQueryValidator : AbstractValidator<GetByTitleNameQuery>
{
    public GetByTitleNameQueryValidator() { }
}