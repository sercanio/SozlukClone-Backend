using Application.Features.Dislikes.Commands.Create;
using Application.Features.Dislikes.Commands.Delete;
using Application.Features.Dislikes.Commands.Update;
using Application.Features.Dislikes.Queries.GetById;
using Application.Features.Dislikes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DislikesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDislikeResponse>> Add([FromBody] CreateDislikeCommand command)
    {
        CreatedDislikeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDislikeResponse>> Update([FromBody] UpdateDislikeCommand command)
    {
        UpdatedDislikeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDislikeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteDislikeCommand command = new() { Id = id };

        DeletedDislikeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDislikeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdDislikeQuery query = new() { Id = id };

        GetByIdDislikeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListDislikeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDislikeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDislikeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}