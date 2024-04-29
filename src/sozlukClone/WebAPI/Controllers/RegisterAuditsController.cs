using Application.Features.RegisterAudits.Queries.GetById;
using Application.Features.RegisterAudits.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterAuditsController : BaseController
{

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdRegisterAuditResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdRegisterAuditQuery query = new() { Id = id };

        GetByIdRegisterAuditResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListRegisterAuditQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRegisterAuditQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListRegisterAuditListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}