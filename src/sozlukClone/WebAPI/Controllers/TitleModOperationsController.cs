using Application.Features.TitleModOperations.Commands.Create;
using Application.Features.TitleModOperations.Commands.Delete;
using Application.Features.TitleModOperations.Commands.Update;
using Application.Features.TitleModOperations.Queries.GetById;
using Application.Features.TitleModOperations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitleModOperationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTitleModOperationResponse>> Add([FromBody] CreateTitleModOperationCommand command)
    {
        CreatedTitleModOperationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTitleModOperationResponse>> Update([FromBody] UpdateTitleModOperationCommand command)
    {
        UpdatedTitleModOperationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTitleModOperationResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTitleModOperationCommand command = new() { Id = id };

        DeletedTitleModOperationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTitleModOperationResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTitleModOperationQuery query = new() { Id = id };

        GetByIdTitleModOperationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTitleModOperationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTitleModOperationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTitleModOperationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}