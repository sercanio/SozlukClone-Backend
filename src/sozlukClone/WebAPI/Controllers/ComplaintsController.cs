using Application.Features.Complaints.Commands.Create;
using Application.Features.Complaints.Commands.Delete;
using Application.Features.Complaints.Commands.Update;
using Application.Features.Complaints.Queries.GetById;
using Application.Features.Complaints.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComplaintsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedComplaintResponse>> Add([FromBody] CreateComplaintCommand command)
    {
        CreatedComplaintResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedComplaintResponse>> Update([FromBody] UpdateComplaintCommand command)
    {
        UpdatedComplaintResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedComplaintResponse>> Delete([FromRoute] Guid id)
    {
        DeleteComplaintCommand command = new() { Id = id };

        DeletedComplaintResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdComplaintResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdComplaintQuery query = new() { Id = id };

        GetByIdComplaintResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListComplaintQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListComplaintQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListComplaintListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}