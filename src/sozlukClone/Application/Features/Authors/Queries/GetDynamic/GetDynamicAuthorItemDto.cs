namespace Application.Features.Authors.Queries.GetDynamic;
public class GetDynamicAuthorItemDto
{
    public uint Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}
