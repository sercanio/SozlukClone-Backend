using Application.Features.TitleFollowings.Commands.Create;
using Application.Features.TitleFollowings.Commands.Delete;
using Application.Features.TitleFollowings.Commands.Update;
using Application.Features.TitleFollowings.Queries.GetById;
using Application.Features.TitleFollowings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TitleFollowings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTitleFollowingCommand, TitleFollowing>();
        CreateMap<TitleFollowing, CreatedTitleFollowingResponse>();

        CreateMap<UpdateTitleFollowingCommand, TitleFollowing>();
        CreateMap<TitleFollowing, UpdatedTitleFollowingResponse>();

        CreateMap<DeleteTitleFollowingCommand, TitleFollowing>();
        CreateMap<TitleFollowing, DeletedTitleFollowingResponse>();

        CreateMap<TitleFollowing, GetByIdTitleFollowingResponse>();

        CreateMap<TitleFollowing, GetListTitleFollowingListItemDto>();
        CreateMap<IPaginate<TitleFollowing>, GetListResponse<GetListTitleFollowingListItemDto>>();
    }
}