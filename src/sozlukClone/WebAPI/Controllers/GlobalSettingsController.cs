using Application.Features.GlobalSettings.Commands.Create;
using Application.Features.GlobalSettings.Commands.Delete;
using Application.Features.GlobalSettings.Commands.Update;
using Application.Features.GlobalSettings.Queries.GetById;
using Application.Features.GlobalSettings.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GlobalSettingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedGlobalSettingResponse>> Add([FromBody] CreateGlobalSettingCommand command)
    {
        CreatedGlobalSettingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    //[HttpPut]
    //public async Task<ActionResult<UpdatedGlobalSettingResponse>> Update([FromBody] UpdateGlobalSettingCommand command)
    //{
    //    UpdatedGlobalSettingResponse response = await Mediator.Send(command);

    //    return Ok(response);
    //}

    [HttpPut]
    public async Task<ActionResult<UpdatedGlobalSettingResponse>> Update([FromForm] UpdateGlobalSettingCommand command)
    {
        UpdatedGlobalSettingResponse response = await Mediator.Send(command);

        return Ok(response);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedGlobalSettingResponse>> Delete([FromRoute] int id)
    {
        DeleteGlobalSettingCommand command = new() { Id = id };

        DeletedGlobalSettingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdGlobalSettingResponse>> GetById([FromRoute] int id)
    {
        GetByIdGlobalSettingQuery query = new() { Id = id };

        GetByIdGlobalSettingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListGlobalSettingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGlobalSettingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListGlobalSettingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}