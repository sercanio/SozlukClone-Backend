using Application.Features.Complaints.Commands.Create;
using Application.Features.Complaints.Commands.Delete;
using Application.Features.Complaints.Commands.Update;
using Application.Features.Complaints.Queries.GetById;
using Application.Features.Complaints.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Complaints.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateComplaintCommand, Complaint>();
        CreateMap<Complaint, CreatedComplaintResponse>();

        CreateMap<UpdateComplaintCommand, Complaint>();
        CreateMap<Complaint, UpdatedComplaintResponse>();

        CreateMap<DeleteComplaintCommand, Complaint>();
        CreateMap<Complaint, DeletedComplaintResponse>();

        CreateMap<Complaint, GetByIdComplaintResponse>();

        CreateMap<Complaint, GetListComplaintListItemDto>();
        CreateMap<IPaginate<Complaint>, GetListResponse<GetListComplaintListItemDto>>();
    }
}