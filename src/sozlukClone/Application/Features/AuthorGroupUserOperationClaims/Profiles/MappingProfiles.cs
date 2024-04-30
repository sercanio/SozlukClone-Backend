using Application.Features.AuthorGroupUserOperationClaims.Commands.Create;
using Application.Features.AuthorGroupUserOperationClaims.Commands.Delete;
using Application.Features.AuthorGroupUserOperationClaims.Commands.Update;
using Application.Features.AuthorGroupUserOperationClaims.Queries.GetById;
using Application.Features.AuthorGroupUserOperationClaims.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorGroupUserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuthorGroupUserOperationClaimCommand, AuthorGroupUserOperationClaim>();
        CreateMap<AuthorGroupUserOperationClaim, CreatedAuthorGroupUserOperationClaimResponse>();

        CreateMap<UpdateAuthorGroupUserOperationClaimCommand, AuthorGroupUserOperationClaim>();
        CreateMap<AuthorGroupUserOperationClaim, UpdatedAuthorGroupUserOperationClaimResponse>();

        CreateMap<DeleteAuthorGroupUserOperationClaimCommand, AuthorGroupUserOperationClaim>();
        CreateMap<AuthorGroupUserOperationClaim, DeletedAuthorGroupUserOperationClaimResponse>();

        CreateMap<AuthorGroupUserOperationClaim, GetByIdAuthorGroupUserOperationClaimResponse>();

        CreateMap<AuthorGroupUserOperationClaim, GetListAuthorGroupUserOperationClaimListItemDto>();
        CreateMap<IPaginate<AuthorGroupUserOperationClaim>, GetListResponse<GetListAuthorGroupUserOperationClaimListItemDto>>();
    }
}