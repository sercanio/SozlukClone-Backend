using Application.Features.TitleFollowings.Commands.Create;
using Application.Features.TitleFollowings.Commands.Delete;
using Application.Features.TitleFollowings.Commands.Update;
using Application.Features.TitleFollowings.Queries.GetById;
using Application.Features.TitleFollowings.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitleFollowingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTitleFollowingResponse>> Add([FromBody] CreateTitleFollowingCommand command)
    {
        CreatedTitleFollowingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTitleFollowingResponse>> Update([FromBody] UpdateTitleFollowingCommand command)
    {
        UpdatedTitleFollowingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTitleFollowingResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTitleFollowingCommand command = new() { Id = id };

        DeletedTitleFollowingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTitleFollowingResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTitleFollowingQuery query = new() { Id = id };

        GetByIdTitleFollowingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTitleFollowingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTitleFollowingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTitleFollowingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}