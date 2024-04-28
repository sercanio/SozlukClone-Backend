using Application.Features.Badges.Commands.Create;
using Application.Features.Badges.Commands.Delete;
using Application.Features.Badges.Commands.Update;
using Application.Features.Badges.Queries.GetById;
using Application.Features.Badges.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BadgesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedBadgeResponse>> Add([FromBody] CreateBadgeCommand command)
    {
        CreatedBadgeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedBadgeResponse>> Update([FromBody] UpdateBadgeCommand command)
    {
        UpdatedBadgeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedBadgeResponse>> Delete([FromRoute] uint id)
    {
        DeleteBadgeCommand command = new() { Id = id };

        DeletedBadgeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdBadgeResponse>> GetById([FromRoute] uint id)
    {
        GetByIdBadgeQuery query = new() { Id = id };

        GetByIdBadgeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListBadgeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBadgeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListBadgeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}