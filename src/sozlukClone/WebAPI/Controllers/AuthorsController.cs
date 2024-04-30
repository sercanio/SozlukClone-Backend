using Application.Features.Authors.Commands.Create;
using Application.Features.Authors.Commands.Delete;
using Application.Features.Authors.Commands.Update;
using Application.Features.Authors.Queries.GetById;
using Application.Features.Authors.Queries.GetDynamic;
using Application.Features.Authors.Queries.GetList;
using Application.Features.Titles.Queries.GetDynamic;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAuthorResponse>> Add([FromBody] CreateAuthorCommand command)
    {
        CreatedAuthorResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAuthorResponse>> Update([FromBody] UpdateAuthorCommand command)
    {
        UpdatedAuthorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAuthorResponse>> Delete([FromRoute] uint id)
    {
        DeleteAuthorCommand command = new() { Id = id };

        DeletedAuthorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAuthorResponse>> GetById([FromRoute] uint id)
    {
        GetByIdAuthorQuery query = new() { Id = id };

        GetByIdAuthorResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAuthorQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAuthorListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpPost("Dynamic")]
    public async Task<ActionResult<GetListResponse<GetDynamicAuthorItemDto>>> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery dynamic)
    {
        GetDynamicAuthorQuery query = new() { DynamicQuery = dynamic, PageRequest = pageRequest };

        GetListResponse<GetDynamicAuthorItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}