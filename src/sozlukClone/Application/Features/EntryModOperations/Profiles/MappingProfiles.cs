using Application.Features.EntryModOperations.Commands.Create;
using Application.Features.EntryModOperations.Commands.Delete;
using Application.Features.EntryModOperations.Commands.Update;
using Application.Features.EntryModOperations.Queries.GetById;
using Application.Features.EntryModOperations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.EntryModOperations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateEntryModOperationCommand, EntryModOperation>();
        CreateMap<EntryModOperation, CreatedEntryModOperationResponse>();

        CreateMap<UpdateEntryModOperationCommand, EntryModOperation>();
        CreateMap<EntryModOperation, UpdatedEntryModOperationResponse>();

        CreateMap<DeleteEntryModOperationCommand, EntryModOperation>();
        CreateMap<EntryModOperation, DeletedEntryModOperationResponse>();

        CreateMap<EntryModOperation, GetByIdEntryModOperationResponse>();

        CreateMap<EntryModOperation, GetListEntryModOperationListItemDto>();
        CreateMap<IPaginate<EntryModOperation>, GetListResponse<GetListEntryModOperationListItemDto>>();
    }
}