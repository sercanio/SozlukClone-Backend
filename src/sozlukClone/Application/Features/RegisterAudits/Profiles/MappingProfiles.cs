using Application.Features.RegisterAudits.Queries.GetById;
using Application.Features.RegisterAudits.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RegisterAudits.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RegisterAudit, GetByIdRegisterAuditResponse>();

        CreateMap<RegisterAudit, GetListRegisterAuditListItemDto>();
        CreateMap<IPaginate<RegisterAudit>, GetListResponse<GetListRegisterAuditListItemDto>>();
    }
}