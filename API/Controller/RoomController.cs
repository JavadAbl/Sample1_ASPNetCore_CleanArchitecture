using Application.Domain.Rooms.Query;
using Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;


public class RoomController(IMediator mediator) : BaseApiController
{
    //--------------------------------------------------------------------
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var room = await mediator.Send(new GetRoomByIdQuery(id));
        return FromResult(room);
    }

    //--------------------------------------------------------------------
    [HttpGet("{number:int}")]
    public async Task<IActionResult> GetByNumber(int number)
    {
        var room = await mediator.Send(new GetRoomByNumberQuery(number));
        return FromResult(room);
    }

    //--------------------------------------------------------------------
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await mediator.Send(new GetAllRoomsQuery());
        return FromResult(rooms);
    }

    //--------------------------------------------------------------------
}
