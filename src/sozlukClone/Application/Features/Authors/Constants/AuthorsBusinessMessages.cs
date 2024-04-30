namespace Application.Features.Authors.Constants;

public static class AuthorsBusinessMessages
{
    public const string SectionName = "Authors";

    public const string AuthorNotExists = "AuthorNotExists";
    public const string AuthorUserNameShouldOnlyHaveLettersAndNumbers = "AuthorUserNameShouldOnlyHaveLettersAndNumbers";
    public const string AuthorUserNameShouldHaveMinumumLength = "AuthorUserNameShouldHaveMinumumLength";
    public const string AuthorUserNameShouldHaveMaximumLength = "AuthorUserNameShouldHaveMaximumLength";
    public const string AuthorUserNameShouldBeUnique = "AuthorUserNameShouldBeUnique";
}