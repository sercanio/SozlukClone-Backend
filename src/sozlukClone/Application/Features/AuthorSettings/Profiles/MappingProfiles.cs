using Application.Features.AuthorSettings.Commands.Create;
using Application.Features.AuthorSettings.Commands.Delete;
using Application.Features.AuthorSettings.Commands.Update;
using Application.Features.AuthorSettings.Queries.GetById;
using Application.Features.AuthorSettings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorSettings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuthorSettingCommand, AuthorSetting>();
        CreateMap<AuthorSetting, CreatedAuthorSettingResponse>();

        CreateMap<UpdateAuthorSettingCommand, AuthorSetting>();
        CreateMap<AuthorSetting, UpdatedAuthorSettingResponse>();

        CreateMap<DeleteAuthorSettingCommand, AuthorSetting>();
        CreateMap<AuthorSetting, DeletedAuthorSettingResponse>();

        CreateMap<AuthorSetting, GetByIdAuthorSettingResponse>();

        CreateMap<AuthorSetting, GetListAuthorSettingListItemDto>();
        CreateMap<IPaginate<AuthorSetting>, GetListResponse<GetListAuthorSettingListItemDto>>();
    }
}