using Application.Features.Likes.Commands.Create;
using Application.Features.Likes.Commands.Delete;
using Application.Features.Likes.Commands.Update;
using Application.Features.Likes.Queries.GetById;
using Application.Features.Likes.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LikesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLikeResponse>> Add([FromBody] CreateLikeCommand command)
    {
        CreatedLikeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLikeResponse>> Update([FromBody] UpdateLikeCommand command)
    {
        UpdatedLikeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLikeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteLikeCommand command = new() { Id = id };

        DeletedLikeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLikeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdLikeQuery query = new() { Id = id };

        GetByIdLikeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLikeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLikeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLikeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}