using Application.Features.AuthorFollowings.Commands.Create;
using Application.Features.AuthorFollowings.Commands.Delete;
using Application.Features.AuthorFollowings.Commands.Update;
using Application.Features.AuthorFollowings.Queries.GetById;
using Application.Features.AuthorFollowings.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorFollowingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAuthorFollowingResponse>> Add([FromBody] CreateAuthorFollowingCommand command)
    {
        CreatedAuthorFollowingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAuthorFollowingResponse>> Update([FromBody] UpdateAuthorFollowingCommand command)
    {
        UpdatedAuthorFollowingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAuthorFollowingResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAuthorFollowingCommand command = new() { Id = id };

        DeletedAuthorFollowingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAuthorFollowingResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAuthorFollowingQuery query = new() { Id = id };

        GetByIdAuthorFollowingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAuthorFollowingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorFollowingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAuthorFollowingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}