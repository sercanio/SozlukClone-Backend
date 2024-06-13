using Application.Features.Entries.Commands.Create;
using Application.Features.Entries.Commands.Delete;
using Application.Features.Entries.Commands.Update;
using Application.Features.Entries.Queries.GetById;
using Application.Features.Entries.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Entries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateEntryCommand, Entry>().ReverseMap();
        CreateMap<UpdateEntryCommand, Entry>().ReverseMap();
        CreateMap<UpdatedEntryResponse, Entry>().ReverseMap();
        CreateMap<DeleteEntryCommand, Entry>().ReverseMap();
        CreateMap<GetByIdEntryResponse, Entry>().ReverseMap();
        CreateMap<CreatedEntryResponse, Entry>().ReverseMap();

        CreateMap<GetListEntryInTitleListItemDTO, Entry>().ForMember(opt => opt.Author, opt => opt.MapFrom(a => a.Author)).ReverseMap();

        CreateMap<GetListEntryListItemDto, Entry>().ForMember(opt => opt.Author, opt => opt.MapFrom(a => a.Author)).ReverseMap();

        CreateMap<IPaginate<Entry>, GetListResponse<GetListEntryListItemDto>>().ReverseMap();
    }
}