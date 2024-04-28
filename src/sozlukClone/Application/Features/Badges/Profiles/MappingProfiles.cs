using Application.Features.Badges.Commands.Create;
using Application.Features.Badges.Commands.Delete;
using Application.Features.Badges.Commands.Update;
using Application.Features.Badges.Queries.GetById;
using Application.Features.Badges.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Badges.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBadgeCommand, Badge>();
        CreateMap<Badge, CreatedBadgeResponse>();

        CreateMap<UpdateBadgeCommand, Badge>();
        CreateMap<Badge, UpdatedBadgeResponse>();

        CreateMap<DeleteBadgeCommand, Badge>();
        CreateMap<Badge, DeletedBadgeResponse>();

        CreateMap<Badge, GetByIdBadgeResponse>();

        CreateMap<Badge, GetListBadgeListItemDto>();
        CreateMap<IPaginate<Badge>, GetListResponse<GetListBadgeListItemDto>>();
    }
}