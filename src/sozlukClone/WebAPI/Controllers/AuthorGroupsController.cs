using Application.Features.AuthorGroups.Commands.Create;
using Application.Features.AuthorGroups.Commands.Delete;
using Application.Features.AuthorGroups.Commands.Update;
using Application.Features.AuthorGroups.Queries.GetById;
using Application.Features.AuthorGroups.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorGroupsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAuthorGroupResponse>> Add([FromBody] CreateAuthorGroupCommand command)
    {
        CreatedAuthorGroupResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAuthorGroupResponse>> Update([FromBody] UpdateAuthorGroupCommand command)
    {
        UpdatedAuthorGroupResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAuthorGroupResponse>> Delete([FromRoute] uint id)
    {
        DeleteAuthorGroupCommand command = new() { Id = id };

        DeletedAuthorGroupResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAuthorGroupResponse>> GetById([FromRoute] uint id)
    {
        GetByIdAuthorGroupQuery query = new() { Id = id };

        GetByIdAuthorGroupResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAuthorGroupQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorGroupQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAuthorGroupListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}