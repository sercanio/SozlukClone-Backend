using Application.Features.Penalties.Commands.Create;
using Application.Features.Penalties.Commands.Delete;
using Application.Features.Penalties.Commands.Update;
using Application.Features.Penalties.Queries.GetById;
using Application.Features.Penalties.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PenaltiesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPenaltyResponse>> Add([FromBody] CreatePenaltyCommand command)
    {
        CreatedPenaltyResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPenaltyResponse>> Update([FromBody] UpdatePenaltyCommand command)
    {
        UpdatedPenaltyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPenaltyResponse>> Delete([FromRoute] Guid id)
    {
        DeletePenaltyCommand command = new() { Id = id };

        DeletedPenaltyResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPenaltyResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdPenaltyQuery query = new() { Id = id };

        GetByIdPenaltyResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPenaltyQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPenaltyQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPenaltyListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}