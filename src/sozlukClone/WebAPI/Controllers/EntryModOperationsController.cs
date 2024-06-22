using Application.Features.EntryModOperations.Commands.Create;
using Application.Features.EntryModOperations.Commands.Delete;
using Application.Features.EntryModOperations.Commands.Update;
using Application.Features.EntryModOperations.Queries.GetById;
using Application.Features.EntryModOperations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntryModOperationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedEntryModOperationResponse>> Add([FromBody] CreateEntryModOperationCommand command)
    {
        CreatedEntryModOperationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedEntryModOperationResponse>> Update([FromBody] UpdateEntryModOperationCommand command)
    {
        UpdatedEntryModOperationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedEntryModOperationResponse>> Delete([FromRoute] Guid id)
    {
        DeleteEntryModOperationCommand command = new() { Id = id };

        DeletedEntryModOperationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdEntryModOperationResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdEntryModOperationQuery query = new() { Id = id };

        GetByIdEntryModOperationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListEntryModOperationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEntryModOperationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListEntryModOperationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}