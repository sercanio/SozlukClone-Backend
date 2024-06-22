using Application.Features.TitleModOperations.Commands.Create;
using Application.Features.TitleModOperations.Commands.Delete;
using Application.Features.TitleModOperations.Commands.Update;
using Application.Features.TitleModOperations.Queries.GetById;
using Application.Features.TitleModOperations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TitleModOperations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTitleModOperationCommand, TitleModOperation>();
        CreateMap<TitleModOperation, CreatedTitleModOperationResponse>();

        CreateMap<UpdateTitleModOperationCommand, TitleModOperation>();
        CreateMap<TitleModOperation, UpdatedTitleModOperationResponse>();

        CreateMap<DeleteTitleModOperationCommand, TitleModOperation>();
        CreateMap<TitleModOperation, DeletedTitleModOperationResponse>();

        CreateMap<TitleModOperation, GetByIdTitleModOperationResponse>();

        CreateMap<TitleModOperation, GetListTitleModOperationListItemDto>();
        CreateMap<IPaginate<TitleModOperation>, GetListResponse<GetListTitleModOperationListItemDto>>();
    }
}