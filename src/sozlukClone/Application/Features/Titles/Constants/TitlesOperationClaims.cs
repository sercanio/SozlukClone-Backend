namespace Application.Features.Titles.Constants;

public static class TitlesOperationClaims
{
    private const string _section = "Titles";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
    
    public const string GetBySlug = $"{_section}.GetBySlug";
    
    public const string GetByTitleName = $"{_section}.GetByTitleName";
}
