using Application.Features.LoginAudits.Queries.GetById;
using Application.Features.LoginAudits.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.LoginAudits.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LoginAudit, GetByIdLoginAuditResponse>();

        CreateMap<LoginAudit, GetListLoginAuditListItemDto>();
        CreateMap<IPaginate<LoginAudit>, GetListResponse<GetListLoginAuditListItemDto>>();
    }
}