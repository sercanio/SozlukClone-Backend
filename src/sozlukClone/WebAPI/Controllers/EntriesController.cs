using Application.Features.Entries.Commands.Create;
using Application.Features.Entries.Commands.Delete;
using Application.Features.Entries.Commands.Update;
using Application.Features.Entries.Queries.GetById;
using Application.Features.Entries.Queries.GetList;
using Application.Features.Entries.Queries.GetListByAuthorId;
using Application.Features.Entries.Queries.GetListByTitleId;
using Application.Features.Entries.Queries.GetListEntryForHomePage;
using Application.Features.Entries.Queries.GetMostFavoritedListByAuthorId;
using Application.Features.Entries.Queries.GetMostLikedListOfYesterday;
using Application.Features.Entries.Queries.GetTopLikedListByAuthorId;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedEntryResponse>> Add([FromBody] CreateEntryCommand command)
    {
        CreatedEntryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedEntryResponse>> Update([FromBody] UpdateEntryCommand command)
    {
        UpdatedEntryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedEntryResponse>> Delete([FromRoute] int id)
    {
        DeleteEntryCommand command = new() { Id = id };

        DeletedEntryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdEntryResponse>> GetById([FromRoute] int id)
    {
        GetByIdEntryQuery query = new() { Id = id };

        GetByIdEntryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListEntryQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEntryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListEntryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("ForHomePage")]
    public async Task<ActionResult<GetListEntryForHomePageQuery>> GetListForHomePage([FromQuery] PageRequest pageRequest)
    {
        GetListEntryForHomePageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListEntryForHomePageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("GetListByAuthorId")]
    public async Task<ActionResult<GetListByAuthorIdListItemDto>> GetListByAuthorId([FromQuery] PageRequest pageRequest, int authorId)
    {
        GetListByAuthorIdQuery query = new() { PageRequest = pageRequest, AuthorId = authorId };

        GetListResponse<GetListByAuthorIdListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("GetTopLikedListByAuthorId")]
    public async Task<ActionResult<GetTopLikedListByAuthorIdResponse>> GetTopLikedListByAuthorId([FromQuery] PageRequest pageRequest, int authorId)
    {
        GetTopLikedListByAuthorIdQuery query = new() { PageRequest = pageRequest, AuthorId = authorId };

        GetListResponse<GetTopLikedListByAuthorIdResponse> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("GetMostFavoritedListByAuthorId")]
    public async Task<ActionResult<GetMostFavoritedListByAuthorIdResponse>> GetMostFavoritedListByAuthorId([FromQuery] PageRequest pageRequest, int authorId)
    {
        GetMostFavoritedListByAuthorIdQuery query = new() { PageRequest = pageRequest, AuthorId = authorId };

        GetListResponse<GetMostFavoritedListByAuthorIdResponse> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("GetListByTitleId")]
    public async Task<ActionResult<GetListByTitleIdQuery>> GetListByTitleId([FromQuery] PageRequest pageRequest, int titleId)
    {
        GetListByTitleIdQuery query = new() { PageRequest = pageRequest, TitleId = titleId };

        GetListResponse<GetListByTitleIdResponse> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("GetMostLikedListOfYesterday")]
    public async Task<ActionResult<GetMostLikedListOfYesterdayQuery>> GetMostLikedListOfYesterday([FromQuery] PageRequest pageRequest)
    {
        GetMostLikedListOfYesterdayQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetMostLikedListOfYesterdayResponse> response = await Mediator.Send(query);
        return Ok(response);
    }
}
