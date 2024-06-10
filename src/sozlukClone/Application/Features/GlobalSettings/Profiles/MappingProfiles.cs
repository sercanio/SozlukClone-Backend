using Application.Features.GlobalSettings.Commands.Create;
using Application.Features.GlobalSettings.Commands.Delete;
using Application.Features.GlobalSettings.Commands.Update;
using Application.Features.GlobalSettings.Queries.GetById;
using Application.Features.GlobalSettings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.GlobalSettings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateGlobalSettingCommand, GlobalSetting>();
        CreateMap<GlobalSetting, CreatedGlobalSettingResponse>();

        CreateMap<UpdateGlobalSettingCommand, GlobalSetting>();
        CreateMap<GlobalSetting, UpdatedGlobalSettingResponse>();

        CreateMap<DeleteGlobalSettingCommand, GlobalSetting>();
        CreateMap<GlobalSetting, DeletedGlobalSettingResponse>();

        CreateMap<GlobalSetting, GetByIdGlobalSettingResponse>();

        CreateMap<GlobalSetting, GetListGlobalSettingListItemDto>();
        CreateMap<IPaginate<GlobalSetting>, GetListResponse<GetListGlobalSettingListItemDto>>();
    }
}