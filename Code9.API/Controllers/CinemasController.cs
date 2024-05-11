
using Code9.Domain.Commands;
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

        [HttpPost]
        public async Task<ActionResult<Cinema>> AddNewCinema(Cinema cinema)
        {
            var command = new AddNewCinemaCommand { Name=cinema.Name, City=cinema.City, Street=cinema.Street, NumberOfAuditoriums=cinema.NumberOfAuditoriums};
            var _cinema = await _mediator.Send(command);
            return Ok(_cinema);
        }
    }
}
