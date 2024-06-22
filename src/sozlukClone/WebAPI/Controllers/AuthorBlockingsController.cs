using Application.Features.AuthorBlockings.Commands.Create;
using Application.Features.AuthorBlockings.Commands.Delete;
using Application.Features.AuthorBlockings.Commands.Update;
using Application.Features.AuthorBlockings.Queries.GetById;
using Application.Features.AuthorBlockings.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorBlockingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAuthorBlockingResponse>> Add([FromBody] CreateAuthorBlockingCommand command)
    {
        CreatedAuthorBlockingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.BlockingId, response.BlockerId }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAuthorBlockingResponse>> Update([FromBody] UpdateAuthorBlockingCommand command)
    {
        UpdatedAuthorBlockingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{blockingId}/{blockerId}")]
    public async Task<ActionResult<DeletedAuthorBlockingResponse>> Delete([FromRoute] int blockingId, int blockerId)
    {
        DeleteAuthorBlockingCommand command = new() { BlockingId = blockingId, BlockerId = blockerId };

        DeletedAuthorBlockingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{blockingId}/{blockerId}")]
    public async Task<ActionResult<GetByIdAuthorBlockingResponse>> GetById([FromRoute] int blockingId, int blockerId)
    {
        GetByIdAuthorBlockingQuery query = new() { BlockingId = blockingId, BlockerId = blockerId };

        GetByIdAuthorBlockingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAuthorBlockingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorBlockingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAuthorBlockingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}