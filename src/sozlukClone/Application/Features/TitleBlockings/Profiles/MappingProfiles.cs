using Application.Features.TitleBlockings.Commands.Create;
using Application.Features.TitleBlockings.Commands.Delete;
using Application.Features.TitleBlockings.Commands.Update;
using Application.Features.TitleBlockings.Queries.GetById;
using Application.Features.TitleBlockings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TitleBlockings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTitleBlockingCommand, TitleBlocking>();
        CreateMap<TitleBlocking, CreatedTitleBlockingResponse>();

        CreateMap<UpdateTitleBlockingCommand, TitleBlocking>();
        CreateMap<TitleBlocking, UpdatedTitleBlockingResponse>();

        CreateMap<DeleteTitleBlockingCommand, TitleBlocking>();
        CreateMap<TitleBlocking, DeletedTitleBlockingResponse>();

        CreateMap<TitleBlocking, GetByIdTitleBlockingResponse>();

        CreateMap<TitleBlocking, GetListTitleBlockingListItemDto>();
        CreateMap<IPaginate<TitleBlocking>, GetListResponse<GetListTitleBlockingListItemDto>>();
    }
}