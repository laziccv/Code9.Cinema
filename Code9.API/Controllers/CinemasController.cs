
using Code9.Domain.Handlers;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public  CinemasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cinema>>> GetAllCinema()
            {
            var query = new GetAllCinemaQuery();
            var cinema = await _mediator.Send(query);
            return Ok(cinema);
            }
    }
}
