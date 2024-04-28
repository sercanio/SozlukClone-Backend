using Application.Features.Penalties.Commands.Create;
using Application.Features.Penalties.Commands.Delete;
using Application.Features.Penalties.Commands.Update;
using Application.Features.Penalties.Queries.GetById;
using Application.Features.Penalties.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Penalties.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePenaltyCommand, Penalty>();
        CreateMap<Penalty, CreatedPenaltyResponse>();

        CreateMap<UpdatePenaltyCommand, Penalty>();
        CreateMap<Penalty, UpdatedPenaltyResponse>();

        CreateMap<DeletePenaltyCommand, Penalty>();
        CreateMap<Penalty, DeletedPenaltyResponse>();

        CreateMap<Penalty, GetByIdPenaltyResponse>();

        CreateMap<Penalty, GetListPenaltyListItemDto>();
        CreateMap<IPaginate<Penalty>, GetListResponse<GetListPenaltyListItemDto>>();
    }
}