using Application.Features.LoginAudits.Queries.GetById;
using Application.Features.LoginAudits.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginAuditsController : BaseController
{

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLoginAuditResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdLoginAuditQuery query = new() { Id = id };

        GetByIdLoginAuditResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLoginAuditQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLoginAuditQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLoginAuditListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}