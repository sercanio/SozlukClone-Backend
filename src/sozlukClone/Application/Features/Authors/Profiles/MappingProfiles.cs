using Application.Features.Authors.Commands.Create;
using Application.Features.Authors.Commands.Delete;
using Application.Features.Authors.Commands.Update;
using Application.Features.Authors.Queries.GetById;
using Application.Features.Authors.Queries.GetByUserName;
using Application.Features.Authors.Queries.GetDynamic;
using Application.Features.Authors.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Authors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuthorCommand, Author>().ReverseMap();
        CreateMap<UpdateAuthorCommand, Author>().ReverseMap();
        CreateMap<DeleteAuthorCommand, Author>().ReverseMap();
        CreateMap<Author, GetByIdAuthorResponse>().ReverseMap();

        CreateMap<Author, GetListAuthorListItemDto>().ReverseMap();
        CreateMap<IPaginate<Author>, GetListResponse<GetListAuthorListItemDto>>().ReverseMap();

        CreateMap<Author, GetDynamicAuthorItemDto>().ReverseMap();
        CreateMap<IPaginate<Author>, GetListResponse<GetDynamicAuthorItemDto>>().ReverseMap();

        CreateMap<Author, GetByUserNameResponse>().ReverseMap();

        CreateMap<Author, GetListAuthorInEntryListItemDto>().ReverseMap();
    }
}