namespace Application.Features.AuthorFollowings.Constants;

public static class AuthorFollowingsBusinessMessages
{
    public const string SectionName = "AuthorFollowings";

    public const string AuthorFollowingNotExists = "AuthorFollowingNotExists";
    public const string FollowingAlreadyExists = "FollowingAlreadyExists";
    public const string FollowingIsOwnerOfItself = "FollowingIsOwnerOfItself";
    public const string BlockingExists = "BlockingExists";
}