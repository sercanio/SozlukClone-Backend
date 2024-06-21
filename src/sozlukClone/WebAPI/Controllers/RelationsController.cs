using Application.Features.Relations.Commands.Create;
using Application.Features.Relations.Commands.Delete;
using Application.Features.Relations.Commands.Update;
using Application.Features.Relations.Queries.GetById;
using Application.Features.Relations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RelationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedRelationResponse>> Add([FromBody] CreateRelationCommand command)
    {
        CreatedRelationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedRelationResponse>> Update([FromBody] UpdateRelationCommand command)
    {
        UpdatedRelationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedRelationResponse>> Delete([FromRoute] Guid id)
    {
        DeleteRelationCommand command = new() { Id = id };

        DeletedRelationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRelationResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdRelationQuery query = new() { Id = id };

        GetByIdRelationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListRelationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRelationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRelationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}