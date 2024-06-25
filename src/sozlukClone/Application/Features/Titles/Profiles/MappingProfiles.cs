using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Update;
using Application.Features.Titles.Queries.GetById;
using Application.Features.Titles.Queries.GetBySlug;
using Application.Features.Titles.Queries.GetDynamic;
using Application.Features.Titles.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Titles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTitleCommand, Title>();
            CreateMap<Title, CreatedTitleResponse>();

            CreateMap<UpdateTitleCommand, Title>();
            CreateMap<Title, UpdatedTitleResponse>();

            CreateMap<DeleteTitleCommand, Title>();
            CreateMap<Title, DeletedTitleResponse>();

            CreateMap<Title, GetByIdTitleResponse>();
            CreateMap<GetByIdTitleResponse, Title>();

            CreateMap<Title, GetTitleBySlugResponse>();
            CreateMap<GetTitleBySlugResponse, Title>();

            CreateMap<Title, GetByTitleNameResponse>();
            CreateMap<GetByTitleNameResponse, Title>();

            CreateMap<Title, GetByIdTitleForEntryResponse>();
            CreateMap<GetByIdTitleForEntryResponse, Title>();

            CreateMap<Title, GetTitleListItemForTitleModOperationsDto>();
            CreateMap<IPaginate<Title>, GetListResponse<GetTitleListItemForTitleModOperationsDto>>();

            CreateMap<Title, GetListTitleListItemDto>();
            CreateMap<IPaginate<Title>, GetListResponse<GetListTitleListItemDto>>();

            CreateMap<Title, GetDynamicTitleItemDto>();
            CreateMap<IPaginate<Title>, GetListResponse<GetDynamicTitleItemDto>>();

        }
    }
}
