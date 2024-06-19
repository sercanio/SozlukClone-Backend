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

        CreateMap<CreateAuthorCommand, Author>();
        CreateMap<Author, CreatedAuthorResponse>();

        CreateMap<UpdateAuthorCommand, Author>();
        CreateMap<Author, UpdatedAuthorResponse>();

        CreateMap<DeleteAuthorCommand, Author>();
        CreateMap<Author, DeletedAuthorResponse>();

        CreateMap<Author, GetByIdAuthorResponse>();

        CreateMap<Author, GetListAuthorListItemDto>();
        CreateMap<IPaginate<Author>, GetListResponse<GetListAuthorListItemDto>>();

        CreateMap<Author, GetDynamicAuthorItemDto>();
        CreateMap<IPaginate<Author>, GetListResponse<GetDynamicAuthorItemDto>>();

        CreateMap<Author, GetByUserNameResponse>();

        CreateMap<Author, GetListAuthorInEntryListItemDto>();
        CreateMap<IPaginate<Author>, GetListResponse<GetListAuthorInEntryListItemDto>>();

        CreateMap<Author, GetByIdAuthorForEntryResponse>();
        CreateMap<GetByIdAuthorForEntryResponse, Author>();

    }
}