using Application.Features.Followings.Commands.Create;
using Application.Features.Followings.Commands.Delete;
using Application.Features.Followings.Commands.Update;
using Application.Features.Followings.Queries.GetById;
using Application.Features.Followings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Followings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFollowingCommand, Following>();
        CreateMap<Following, CreatedFollowingResponse>();

        CreateMap<UpdateFollowingCommand, Following>();
        CreateMap<Following, UpdatedFollowingResponse>();

        CreateMap<DeleteFollowingCommand, Following>();
        CreateMap<Following, DeletedFollowingResponse>();

        CreateMap<Following, GetByIdFollowingResponse>();

        CreateMap<Following, GetListFollowingListItemDto>();
        CreateMap<IPaginate<Following>, GetListResponse<GetListFollowingListItemDto>>();
    }
}