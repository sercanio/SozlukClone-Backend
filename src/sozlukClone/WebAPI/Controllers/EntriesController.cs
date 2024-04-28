using Application.Features.Entries.Commands.Create;
using Application.Features.Entries.Commands.Delete;
using Application.Features.Entries.Commands.Update;
using Application.Features.Entries.Queries.GetById;
using Application.Features.Entries.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedEntryResponse>> Add([FromBody] CreateEntryCommand command)
    {
        CreatedEntryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedEntryResponse>> Update([FromBody] UpdateEntryCommand command)
    {
        UpdatedEntryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedEntryResponse>> Delete([FromRoute] uint id)
    {
        DeleteEntryCommand command = new() { Id = id };

        DeletedEntryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdEntryResponse>> GetById([FromRoute] uint id)
    {
        GetByIdEntryQuery query = new() { Id = id };

        GetByIdEntryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListEntryQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEntryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListEntryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}