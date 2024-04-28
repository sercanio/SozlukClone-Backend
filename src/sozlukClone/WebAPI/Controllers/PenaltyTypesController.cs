using Application.Features.PenaltyTypes.Commands.Create;
using Application.Features.PenaltyTypes.Commands.Delete;
using Application.Features.PenaltyTypes.Commands.Update;
using Application.Features.PenaltyTypes.Queries.GetById;
using Application.Features.PenaltyTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PenaltyTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPenaltyTypeResponse>> Add([FromBody] CreatePenaltyTypeCommand command)
    {
        CreatedPenaltyTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPenaltyTypeResponse>> Update([FromBody] UpdatePenaltyTypeCommand command)
    {
        UpdatedPenaltyTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPenaltyTypeResponse>> Delete([FromRoute] uint id)
    {
        DeletePenaltyTypeCommand command = new() { Id = id };

        DeletedPenaltyTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPenaltyTypeResponse>> GetById([FromRoute] uint id)
    {
        GetByIdPenaltyTypeQuery query = new() { Id = id };

        GetByIdPenaltyTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPenaltyTypeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPenaltyTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPenaltyTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}