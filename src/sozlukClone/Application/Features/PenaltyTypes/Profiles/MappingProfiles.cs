using Application.Features.PenaltyTypes.Commands.Create;
using Application.Features.PenaltyTypes.Commands.Delete;
using Application.Features.PenaltyTypes.Commands.Update;
using Application.Features.PenaltyTypes.Queries.GetById;
using Application.Features.PenaltyTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PenaltyTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePenaltyTypeCommand, PenaltyType>();
        CreateMap<PenaltyType, CreatedPenaltyTypeResponse>();

        CreateMap<UpdatePenaltyTypeCommand, PenaltyType>();
        CreateMap<PenaltyType, UpdatedPenaltyTypeResponse>();

        CreateMap<DeletePenaltyTypeCommand, PenaltyType>();
        CreateMap<PenaltyType, DeletedPenaltyTypeResponse>();

        CreateMap<PenaltyType, GetByIdPenaltyTypeResponse>();

        CreateMap<PenaltyType, GetListPenaltyTypeListItemDto>();
        CreateMap<IPaginate<PenaltyType>, GetListResponse<GetListPenaltyTypeListItemDto>>();
    }
}