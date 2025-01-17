using Application.Features.TitleBlockings.Commands.Create;
using Application.Features.TitleBlockings.Commands.Delete;
using Application.Features.TitleBlockings.Commands.Update;
using Application.Features.TitleBlockings.Queries.GetById;
using Application.Features.TitleBlockings.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitleBlockingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTitleBlockingResponse>> Add([FromBody] CreateTitleBlockingCommand command)
    {
        CreatedTitleBlockingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTitleBlockingResponse>> Update([FromBody] UpdateTitleBlockingCommand command)
    {
        UpdatedTitleBlockingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTitleBlockingResponse>> Delete([FromRoute] Guid id)
    {
        DeleteTitleBlockingCommand command = new() { Id = id };

        DeletedTitleBlockingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTitleBlockingResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdTitleBlockingQuery query = new() { Id = id };

        GetByIdTitleBlockingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTitleBlockingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTitleBlockingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTitleBlockingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}