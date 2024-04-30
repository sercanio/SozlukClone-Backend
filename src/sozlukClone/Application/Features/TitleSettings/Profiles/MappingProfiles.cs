using Application.Features.TitleSettings.Commands.Update;
using Application.Features.TitleSettings.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.TitleSettings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UpdateTitleSettingCommand, TitleSetting>();
        CreateMap<TitleSetting, UpdatedTitleSettingResponse>();

        CreateMap<TitleSetting, GetByIdTitleSettingResponse>();
    }
}