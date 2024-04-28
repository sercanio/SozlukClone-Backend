using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Users.Queries.GetList;

public class GetListUserListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public GetListUserListItemDto()
    {
        Email = string.Empty;
    }

    public GetListUserListItemDto(Guid id, string email, bool status)
    {
        Id = id;
        Email = email;
        Status = status;
    }
}
