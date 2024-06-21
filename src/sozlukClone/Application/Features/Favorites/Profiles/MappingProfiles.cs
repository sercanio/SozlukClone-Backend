using Application.Features.Favorites.Commands.Create;
using Application.Features.Favorites.Commands.Delete;
using Application.Features.Favorites.Commands.Update;
using Application.Features.Favorites.Queries.GetById;
using Application.Features.Favorites.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Favorites.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFavoriteCommand, Favorite>();
        CreateMap<Favorite, CreatedFavoriteResponse>();

        CreateMap<UpdateFavoriteCommand, Favorite>();
        CreateMap<Favorite, UpdatedFavoriteResponse>();

        CreateMap<DeleteFavoriteCommand, Favorite>();
        CreateMap<Favorite, DeletedFavoriteResponse>();

        CreateMap<Favorite, GetByIdFavoriteResponse>();

        CreateMap<Favorite, GetListFavoriteListItemDto>();
        CreateMap<IPaginate<Favorite>, GetListResponse<GetListFavoriteListItemDto>>();

        CreateMap<Favorite, GetListFavoriteListItemInEntryDto>();
        CreateMap<GetListFavoriteListItemInEntryDto, Favorite>();
    }
}