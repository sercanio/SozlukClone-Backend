using Application.Features.Relations.Commands.Create;
using Application.Features.Relations.Commands.Delete;
using Application.Features.Relations.Commands.Update;
using Application.Features.Relations.Queries.GetById;
using Application.Features.Relations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Relations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRelationCommand, Relation>();
        CreateMap<Relation, CreatedRelationResponse>();

        CreateMap<UpdateRelationCommand, Relation>();
        CreateMap<Relation, UpdatedRelationResponse>();

        CreateMap<DeleteRelationCommand, Relation>();
        CreateMap<Relation, DeletedRelationResponse>();

        CreateMap<Relation, GetByIdRelationResponse>();

        CreateMap<Relation, GetListRelationListItemDto>();
        CreateMap<IPaginate<Relation>, GetListResponse<GetListRelationListItemDto>>();
    }
}