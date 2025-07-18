using Application.Domain.Rooms.Command;
using Application.Domain.Rooms.Query;
using Domain.Dto;
using Domain.Dto.Room;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;


public class RoomController(IMediator mediator) : BaseApiController
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id) => FromResult(await mediator.Send(new GetRoomByIdQuery(id)));

    [HttpGet("{number:int}")]
    public async Task<IActionResult> GetByNumber(int number) => FromResult(await mediator.Send(new GetRoomByNumberQuery(number)));

    [HttpGet]
    public async Task<IActionResult> GetAll() => FromResult(await mediator.Send(new GetAllRoomsQuery()));

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoomDto dto) => FromResult(await mediator.Send(new CreateRoomCommand(dto)));

    [HttpPut]
    public async Task<IActionResult> Update(UpdateRoomDto dto) => FromResult(await mediator.Send(new UpdateRoomCommand(dto)));

    [HttpPut]
    public async Task<IActionResult> AddGuestToRoom(AddGuestToRoomDto dto) => FromResult(await mediator.Send(new AddGuestToRoomCommand(dto)));

}
