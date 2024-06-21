using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Commands.Delete;
using Application.Features.Likes.Commands.Update;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Likes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLikeCommand, Like>();
        CreateMap<Like, CreatedLikeResponse>();

        CreateMap<UpdateLikeCommand, Like>();
        CreateMap<Like, UpdatedLikeResponse>();

        CreateMap<DeleteLikeCommand, Like>();
        CreateMap<Like, DeletedLikeResponse>();

        CreateMap<Like, GetByIdLikeResponse>();

        CreateMap<Like, GetListLikeListItemDto>();
        CreateMap<IPaginate<Like>, GetListResponse<GetListLikeListItemDto>>();

        CreateMap<Like, GetListLikeListItemInEntryDto>();
        CreateMap<GetListLikeListItemInEntryDto, Like>();
    }
}