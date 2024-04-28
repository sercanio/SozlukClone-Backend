using Application.Features.Followings.Commands.Create;
using Application.Features.Followings.Commands.Delete;
using Application.Features.Followings.Queries.GetById;
using Application.Features.Followings.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FollowingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFollowingResponse>> Add([FromBody] CreateFollowingCommand command)
    {
        CreatedFollowingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.FollowerId, response.FollowedId }, response);
    }

    //[HttpPut]
    //public async Task<ActionResult<UpdatedFollowingResponse>> Update([FromBody] UpdateFollowingCommand command)
    //{
    //    UpdatedFollowingResponse response = await Mediator.Send(command);

    //    return Ok(response);
    //}

    [HttpDelete("{followerId}/{followedId}")]
    public async Task<ActionResult<DeletedFollowingResponse>> Delete([FromRoute] uint followerId, [FromRoute] uint followedId)
    {
        DeleteFollowingCommand command = new()
        {
            FollowedId = followedId,
            FollowerId = followerId
        };

        DeletedFollowingResponse response = await Mediator.Send(command);

        return Ok(response);
    }


    [HttpGet("{followerId}/{followedId}")]
    public async Task<ActionResult<GetByIdFollowingResponse>> GetById([FromRoute] uint followerId, [FromRoute] uint followedId)
    {
        GetByIdFollowingQuery query = new()
        {
            FollowerId = followerId,
            FollowedId = followedId
        };

        GetByIdFollowingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListFollowingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFollowingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFollowingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}