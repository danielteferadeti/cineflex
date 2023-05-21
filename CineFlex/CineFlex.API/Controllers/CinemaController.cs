using BlogApp.Application.Responses;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
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

        [HttpGet]
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

      
    }
}

