namespace Application.Features.Entries.Constants;

public static class EntriesOperationClaims
{
    private const string _section = "Entries";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
    
    public const string GetListEntryHomePageQuery = $"{_section}.GetListEntryHomePageQuery";
    
    public const string GetListEntryForHomePage = $"{_section}.GetListEntryForHomePage";
    
    public const string GetByAuthorId = $"{_section}.GetByAuthorId";
    
    public const string GetListByAuthorId = $"{_section}.GetListByAuthorId";
    
    public const string GetTopLikedListByAuthorId = $"{_section}.GetTopLikedListByAuthorId";
    
    public const string GetMostFavoritedListByAuthorId = $"{_section}.GetMostFavoritedListByAuthorId";
    
    public const string GetListByTitleId = $"{_section}.GetListByTitleId";
    
    public const string GetMostLikedListOfYesterday = $"{_section}.GetMostLikedListOfYesterday";
}
