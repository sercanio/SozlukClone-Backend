using Application.Features.AuthorGroups.Queries.GetList;
using Application.Features.Entries.Commands.Create;
using Application.Features.Entries.Commands.Delete;
using Application.Features.Entries.Commands.Update;
using Application.Features.Entries.Queries.GetById;
using Application.Features.Entries.Queries.GetList;
using Application.Features.Entries.Queries.GetListByAuthorId;
using Application.Features.Entries.Queries.GetListEntryForHomePage;
using Application.Features.Entries.Queries.GetMostFavoritedListByAuthorId;
using Application.Features.Entries.Queries.GetTopLikedListByAuthorId;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {

        CreateMap<CreateEntryCommand, Entry>();
        CreateMap<Entry, CreatedEntryResponse>();

        CreateMap<UpdateEntryCommand, Entry>();
        CreateMap<Entry, UpdatedEntryResponse>();

        CreateMap<DeleteEntryCommand, Entry>();
        CreateMap<Entry, DeletedEntryResponse>();

        CreateMap<Entry, GetByIdEntryResponse>();
        CreateMap<GetByIdEntryResponse, Entry>();

        CreateMap<Entry, GetListEntryListItemDto>();
        CreateMap<IPaginate<Entry>, GetListResponse<GetListEntryListItemDto>>();

        CreateMap<Entry, GetListEntryInTitleListItemDTO>();
        CreateMap<GetListEntryInTitleListItemDTO, Entry>();

        CreateMap<Entry, GetListEntryForHomePageDto>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));
        CreateMap<IPaginate<Entry>, GetListResponse<GetListEntryForHomePageDto>>();

        CreateMap<Entry, GetListByAuthorIdResponse>();
        CreateMap<IPaginate<Entry>, GetListResponse<GetListByAuthorIdResponse>>();

        CreateMap<Author, GetListAuthorGroupListItemInEntryDto>();
        CreateMap<GetListAuthorGroupListItemInEntryDto, Author>();

        CreateMap<Entry, GetTopLikedListByAuthorIdResponse>();
        CreateMap<IPaginate<Entry>, GetListResponse<GetTopLikedListByAuthorIdResponse>>();

        CreateMap<Entry, GetMostFavoritedListByAuthorIdResponse>();
        CreateMap<IPaginate<Entry>, GetListResponse<GetMostFavoritedListByAuthorIdResponse>>();
    }
}