using Application.Features.Entries.Commands.Create;
using Application.Features.Entries.Commands.Delete;
using Application.Features.Entries.Commands.Update;
using Application.Features.Entries.Queries.GetById;
using Application.Features.Entries.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
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

        CreateMap<Entry, GetListEntryListItemDto>();
        CreateMap<IPaginate<Entry>, GetListResponse<GetListEntryListItemDto>>();
    }
}