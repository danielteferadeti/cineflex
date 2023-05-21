using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    public class CinemaController:ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CinemaDto>>> Get()
        {
            var Cinemas = await _mediator.Send(new GetCinemaListQuery());
            return Ok(Cinemas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaDto>> Get(int id)
        {
            var Cinema = await _mediator.Send(new GetCinemaQuery { Id = id });
            return Ok(Cinema);
        }
        [HttpPost("CreateCinema")]
        public async Task<ActionResult> Post([FromBody] CreateCinemaDto createCinemaDto)
        {
            var command = new CreateCinemaCommand { CinemaDto = createCinemaDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }
        [HttpPut("UpdateCinema")]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaDto updateCinemaDto)
        {
            var command = new UpdateCinemaCommand { updateCinemaDto = updateCinemaDto };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCinemaCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

