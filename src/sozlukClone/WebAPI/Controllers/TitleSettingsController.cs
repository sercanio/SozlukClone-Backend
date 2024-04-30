using Application.Features.TitleSettings.Commands.Update;
using Application.Features.TitleSettings.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TitleSettingsController : BaseController
{
    [HttpPut]
    public async Task<ActionResult<UpdatedTitleSettingResponse>> Update([FromBody] UpdateTitleSettingCommand command)
    {
        UpdatedTitleSettingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTitleSettingResponse>> GetById([FromRoute] uint id)
    {
        GetByIdTitleSettingQuery query = new() { Id = id };

        GetByIdTitleSettingResponse response = await Mediator.Send(query);

        return Ok(response);
    }
}