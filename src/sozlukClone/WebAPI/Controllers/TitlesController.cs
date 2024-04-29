using Application.Features.Titles.Commands.Create;
using Application.Features.Titles.Commands.Delete;
using Application.Features.Titles.Commands.Update;
using Application.Features.Titles.Queries.GetById;
using Application.Features.Titles.Queries.GetDynamic;
using Application.Features.Titles.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitlesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTitleResponse>> Add([FromBody] CreateTitleCommand command)
    {
        CreatedTitleResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTitleResponse>> Update([FromBody] UpdateTitleCommand command)
    {
        UpdatedTitleResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTitleResponse>> Delete([FromRoute] uint id)
    {
        DeleteTitleCommand command = new() { Id = id };

        DeletedTitleResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTitleResponse>> GetById([FromRoute] uint id)
    {
        GetByIdTitleQuery query = new() { Id = id };

        GetByIdTitleResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTitleQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTitleQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTitleListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("Dynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicTitleItemDto>>> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
    {
        GetDynamicTitleQuery query = new() { DynamicQuery = dynamic, PageRequest = pageRequest };

        GetListResponse<GetDynamicTitleItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}