using Application.Features.AuthorGroupUserOperationClaims.Commands.Create;
using Application.Features.AuthorGroupUserOperationClaims.Commands.Delete;
using Application.Features.AuthorGroupUserOperationClaims.Commands.Update;
using Application.Features.AuthorGroupUserOperationClaims.Queries.GetById;
using Application.Features.AuthorGroupUserOperationClaims.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorGroupUserOperationClaimsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAuthorGroupUserOperationClaimResponse>> Add([FromBody] CreateAuthorGroupUserOperationClaimCommand command)
    {
        CreatedAuthorGroupUserOperationClaimResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAuthorGroupUserOperationClaimResponse>> Update([FromBody] UpdateAuthorGroupUserOperationClaimCommand command)
    {
        UpdatedAuthorGroupUserOperationClaimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAuthorGroupUserOperationClaimResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAuthorGroupUserOperationClaimCommand command = new() { Id = id };

        DeletedAuthorGroupUserOperationClaimResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAuthorGroupUserOperationClaimResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAuthorGroupUserOperationClaimQuery query = new() { Id = id };

        GetByIdAuthorGroupUserOperationClaimResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAuthorGroupUserOperationClaimQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorGroupUserOperationClaimQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAuthorGroupUserOperationClaimListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}