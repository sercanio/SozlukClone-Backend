using Application.Features.AuthorBlockings.Commands.Create;
using Application.Features.AuthorBlockings.Commands.Delete;
using Application.Features.AuthorBlockings.Commands.Update;
using Application.Features.AuthorBlockings.Queries.GetById;
using Application.Features.AuthorBlockings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AuthorBlockings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAuthorBlockingCommand, AuthorBlocking>();
        CreateMap<AuthorBlocking, CreatedAuthorBlockingResponse>();

        CreateMap<UpdateAuthorBlockingCommand, AuthorBlocking>();
        CreateMap<AuthorBlocking, UpdatedAuthorBlockingResponse>();

        CreateMap<DeleteAuthorBlockingCommand, AuthorBlocking>();
        CreateMap<AuthorBlocking, DeletedAuthorBlockingResponse>();

        CreateMap<AuthorBlocking, GetByIdAuthorBlockingResponse>();

        CreateMap<AuthorBlocking, GetListAuthorBlockingListItemDto>();
        CreateMap<IPaginate<AuthorBlocking>, GetListResponse<GetListAuthorBlockingListItemDto>>();
    }
}