using Application.Features.AuthorSettings.Commands.Update;
using Application.Features.AuthorSettings.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorSettingsController : BaseController
{
    [HttpPut]
    public async Task<ActionResult<UpdatedAuthorSettingResponse>> Update([FromBody] UpdateAuthorSettingCommand command)
    {
        UpdatedAuthorSettingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAuthorSettingResponse>> GetById([FromRoute] uint id)
    {
        GetByIdAuthorSettingQuery query = new() { Id = id };

        GetByIdAuthorSettingResponse response = await Mediator.Send(query);

        return Ok(response);
    }
}