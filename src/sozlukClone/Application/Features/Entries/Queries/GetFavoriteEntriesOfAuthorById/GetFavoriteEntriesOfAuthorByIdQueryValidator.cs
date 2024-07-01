using FluentValidation;

namespace Application.Features.Entries.Queries.GetFavoriteEntriesOfAuthorById;

public class GetFavoriteEntriesOfAuthorByIdQueryValidator : AbstractValidator<GetFavoriteEntriesOfAuthorByIdQuery>
{
    public GetFavoriteEntriesOfAuthorByIdQueryValidator() { }
}