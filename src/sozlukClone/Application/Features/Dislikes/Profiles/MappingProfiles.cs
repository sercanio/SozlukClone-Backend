using Application.Features.Dislikes.Commands.Create;
using Application.Features.Dislikes.Commands.Delete;
using Application.Features.Dislikes.Commands.Update;
using Application.Features.Dislikes.Queries.GetById;
using Application.Features.Dislikes.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Dislikes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDislikeCommand, Dislike>();
        CreateMap<Dislike, CreatedDislikeResponse>();

        CreateMap<UpdateDislikeCommand, Dislike>();
        CreateMap<Dislike, UpdatedDislikeResponse>();

        CreateMap<DeleteDislikeCommand, Dislike>();
        CreateMap<Dislike, DeletedDislikeResponse>();

        CreateMap<Dislike, GetByIdDislikeResponse>();

        CreateMap<Dislike, GetListDislikeListItemDto>();
        CreateMap<IPaginate<Dislike>, GetListResponse<GetListDislikeListItemDto>>();

        CreateMap<Dislike, GetListDislikeListItemInEntryDto>();
        CreateMap<GetListDislikeListItemInEntryDto, Dislike>();
    }
}