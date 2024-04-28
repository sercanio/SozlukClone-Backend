using Application.Features.AuthorGroups.Commands.Create;
using Application.Features.AuthorGroups.Commands.Delete;
using Application.Features.AuthorGroups.Commands.Update;
using Application.Features.AuthorGroups.Queries.GetById;
using Application.Features.AuthorGroups.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorGroups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuthorGroupCommand, AuthorGroup>();
        CreateMap<AuthorGroup, CreatedAuthorGroupResponse>();

        CreateMap<UpdateAuthorGroupCommand, AuthorGroup>();
        CreateMap<AuthorGroup, UpdatedAuthorGroupResponse>();

        CreateMap<DeleteAuthorGroupCommand, AuthorGroup>();
        CreateMap<AuthorGroup, DeletedAuthorGroupResponse>();

        CreateMap<AuthorGroup, GetByIdAuthorGroupResponse>();

        CreateMap<AuthorGroup, GetListAuthorGroupListItemDto>();
        CreateMap<IPaginate<AuthorGroup>, GetListResponse<GetListAuthorGroupListItemDto>>();
    }
}