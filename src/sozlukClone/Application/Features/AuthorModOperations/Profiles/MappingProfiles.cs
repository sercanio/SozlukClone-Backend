using Application.Features.AuthorModOperations.Commands.Create;
using Application.Features.AuthorModOperations.Commands.Delete;
using Application.Features.AuthorModOperations.Commands.Update;
using Application.Features.AuthorModOperations.Queries.GetById;
using Application.Features.AuthorModOperations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorModOperations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuthorModOperationCommand, AuthorModOperation>();
        CreateMap<AuthorModOperation, CreatedAuthorModOperationResponse>();

        CreateMap<UpdateAuthorModOperationCommand, AuthorModOperation>();
        CreateMap<AuthorModOperation, UpdatedAuthorModOperationResponse>();

        CreateMap<DeleteAuthorModOperationCommand, AuthorModOperation>();
        CreateMap<AuthorModOperation, DeletedAuthorModOperationResponse>();

        CreateMap<AuthorModOperation, GetByIdAuthorModOperationResponse>();

        CreateMap<AuthorModOperation, GetListAuthorModOperationListItemDto>();
        CreateMap<IPaginate<AuthorModOperation>, GetListResponse<GetListAuthorModOperationListItemDto>>();
    }
}