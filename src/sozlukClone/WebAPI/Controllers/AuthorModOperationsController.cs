using Application.Features.AuthorModOperations.Commands.Create;
using Application.Features.AuthorModOperations.Commands.Delete;
using Application.Features.AuthorModOperations.Commands.Update;
using Application.Features.AuthorModOperations.Queries.GetById;
using Application.Features.AuthorModOperations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorModOperationsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAuthorModOperationResponse>> Add([FromBody] CreateAuthorModOperationCommand command)
    {
        CreatedAuthorModOperationResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAuthorModOperationResponse>> Update([FromBody] UpdateAuthorModOperationCommand command)
    {
        UpdatedAuthorModOperationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAuthorModOperationResponse>> Delete([FromRoute] Guid id)
    {
        DeleteAuthorModOperationCommand command = new() { Id = id };

        DeletedAuthorModOperationResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAuthorModOperationResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdAuthorModOperationQuery query = new() { Id = id };

        GetByIdAuthorModOperationResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAuthorModOperationQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAuthorModOperationQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAuthorModOperationListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}