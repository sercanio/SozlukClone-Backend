using Application.Features.Favorites.Commands.Create;
using Application.Features.Favorites.Commands.Delete;
using Application.Features.Favorites.Commands.Update;
using Application.Features.Favorites.Queries.GetById;
using Application.Features.Favorites.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoritesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFavoriteResponse>> Add([FromBody] CreateFavoriteCommand command)
    {
        CreatedFavoriteResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedFavoriteResponse>> Update([FromBody] UpdateFavoriteCommand command)
    {
        UpdatedFavoriteResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedFavoriteResponse>> Delete([FromRoute] Guid id)
    {
        DeleteFavoriteCommand command = new() { Id = id };

        DeletedFavoriteResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdFavoriteResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdFavoriteQuery query = new() { Id = id };

        GetByIdFavoriteResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListFavoriteQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFavoriteQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFavoriteListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}