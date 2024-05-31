using FluentValidation;

namespace Application.Features.Authors.Queries.GetByUserName;

public class GetByUserNameQueryValidator : AbstractValidator<GetByUserNameQuery>
{
    public GetByUserNameQueryValidator() { }
}