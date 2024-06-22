using Application.Features.AuthorFollowings.Commands.Create;
using Application.Features.AuthorFollowings.Commands.Delete;
using Application.Features.AuthorFollowings.Commands.Update;
using Application.Features.AuthorFollowings.Queries.GetById;
using Application.Features.AuthorFollowings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorFollowings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuthorFollowingCommand, AuthorFollowing>();
        CreateMap<AuthorFollowing, CreatedAuthorFollowingResponse>();

        CreateMap<UpdateAuthorFollowingCommand, AuthorFollowing>();
        CreateMap<AuthorFollowing, UpdatedAuthorFollowingResponse>();

        CreateMap<DeleteAuthorFollowingCommand, AuthorFollowing>();
        CreateMap<AuthorFollowing, DeletedAuthorFollowingResponse>();

        CreateMap<AuthorFollowing, GetByIdAuthorFollowingResponse>();

        CreateMap<AuthorFollowing, GetListAuthorFollowingListItemDto>();
        CreateMap<IPaginate<AuthorFollowing>, GetListResponse<GetListAuthorFollowingListItemDto>>();
    }
}