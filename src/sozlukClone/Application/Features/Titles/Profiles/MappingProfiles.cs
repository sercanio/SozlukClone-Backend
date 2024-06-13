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
            CreateMap<CreateTitleCommand, Title>().ReverseMap();

            CreateMap<UpdateTitleCommand, Title>().ReverseMap();

            CreateMap<DeleteTitleCommand, Title>().ReverseMap();

            CreateMap<GetByIdTitleQuery, Title>().ReverseMap();

            CreateMap<GetTitleBySlugResponse, Title>().ReverseMap();

            CreateMap<GetByIdTitleResponse, Title>().ReverseMap();

            CreateMap<Title, GetListTitleListItemDto>().ReverseMap();
            CreateMap<IPaginate<Title>, GetListResponse<GetListTitleListItemDto>>().ReverseMap();


            CreateMap<Title, GetDynamicTitleItemDto>().ReverseMap();
            CreateMap<IPaginate<Title>, GetListResponse<GetListTitleListItemDto>>().ReverseMap();
        }
    }
}
